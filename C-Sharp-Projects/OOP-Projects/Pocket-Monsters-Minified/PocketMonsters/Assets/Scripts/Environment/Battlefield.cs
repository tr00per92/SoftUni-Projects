namespace Environment
{
    using UnityEngine;
    using System.Collections;
    using System.Linq;

    using Scripts;
    using Abilities;
    using Creatures;
    using Interfaces;
    using Pokemons;
    using System.Collections.Generic;

    public class Battlefield : MonoBehaviour
    {
        public UILabel playerPokemonNameLabel;
        public UILabel enemyPokemonNameLabel;
        public UILabel playerPokemonLevelLabel;
        public UILabel enemyPokemonLevelLabel;
        public UILabel playerPokemonHealthLabel;
        public UILabel actionResultLabel;

        public GameObject playerPokemonImage;
        public GameObject enemyPokemonImage;
        public GameObject actionButtons;
        public GameObject specialActionsButtons;
        public GameObject firstSpecialButton;
        public GameObject secondSpecialButton;
        public GameObject thirdSpecialButton;
        public GameObject fourthSpecialButton;
        public GameObject notificationPopup;
        public GameObject fightResultPopup;

        public UIProgressBar playerHealthBar;
        public UIProgressBar enemyHealthBar;

        private System.Random randomNumberGenerator;
        private IPokemon playerActivePokemon;
        private IPokemon enemyActivePokemon;
        private string actionMessage;

        private bool playerTurn;
        private bool enemyTurn;
        private bool enemyUsedAbility;
        private bool duelEnded;

        void Start()
        {
            this.randomNumberGenerator = new System.Random();
            this.playerTurn = true;

            PlayerSelectPokemon();
            EnemySelectPokemon();
        }

        void Update()
        {
            if (!this.duelEnded)
            {
                if (this.playerTurn && this.actionResultLabel.gameObject.activeInHierarchy)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        this.playerTurn = false;
                        this.enemyTurn = true;
                        this.enemyUsedAbility = false;
                        DecreaseAbilityCooldowns(this.enemyActivePokemon);
                    }
                }
                else if (this.enemyTurn && this.actionResultLabel.gameObject.activeInHierarchy)
                {
                    if (!this.enemyUsedAbility)
                    {
                        EnemyExecuteTurn();
                    }

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        this.playerTurn = true;
                        this.enemyTurn = false;
                        this.actionResultLabel.gameObject.SetActive(false);
                        this.actionButtons.SetActive(true);
                        DecreaseAbilityCooldowns(this.playerActivePokemon);
                    }
                }
            }
        }

        public void UseNormalAttack()
        {
            if (this.notificationPopup.activeInHierarchy || this.duelEnded)
            {
                return;
            }

            this.enemyActivePokemon.CurrentHealth -= this.playerActivePokemon.AttackDamage;
            UpdateEnemyStats();

            this.actionMessage = string.Format("Player's {0} hit enemy's {1} for {2} Damage.",
                this.playerActivePokemon.GetType().Name, this.enemyActivePokemon.GetType().Name,
                this.playerActivePokemon.AttackDamage);
            ShowActionResult(this.actionMessage);
            
            if (this.enemyActivePokemon.CurrentHealth <= 0)
            {
                this.enemyActivePokemon.IsAlive = false;
                EnemySelectPokemon();
            }
        }

        public void UseSpecialAttack(GameObject buttonPressed)
        {
            if (this.notificationPopup.activeInHierarchy || this.duelEnded)
            {
                return;
            }

            int abilityIndex = int.Parse(buttonPressed.name.Substring(0, buttonPressed.name.IndexOf('_')));
            SpecialAbility usedAbility = (SpecialAbility)this.playerActivePokemon.Abilities[abilityIndex];

            if (usedAbility.CurrentCooldown > 0)
            {
                ShowNotification();
                return;
            }
            else
            {
                if (SpecialAbility.TargetIsHit(usedAbility))
                {
                    this.actionMessage = usedAbility.HitMessage;

                    if (usedAbility.GetType().BaseType == typeof(DamageAbility))
                    {
                        this.actionMessage += string.Format(" The target suffers {0} damage.", usedAbility.AbilityPower);
                        ((DamageAbility)usedAbility).Hit(this.enemyActivePokemon);

                        if (this.enemyActivePokemon.CurrentHealth <= 0)
                        {
                            this.enemyActivePokemon.IsAlive = false;
                            EnemySelectPokemon();
                        }
                    }
                    else if (usedAbility.GetType().BaseType == typeof(HealAbility))
                    {
                        this.actionMessage += string.Format(" The target recieves {0} health.", usedAbility.AbilityPower);
                        ((HealAbility)usedAbility).Heal(this.playerActivePokemon);
                    }
                }
                else
                {
                    this.actionMessage = usedAbility.MissMessage;
                }

                usedAbility.CurrentCooldown = usedAbility.BaseCooldown;
                this.specialActionsButtons.SetActive(false);
                ShowActionResult(this.actionMessage);
                UpdatePlayerStats();
                UpdateEnemyStats();
            }
        }
        
        private void PlayerSelectPokemon() 
        {
            var alivePlayerPokemons = GameData.player.Pokemons.Where(p => p.IsAlive).ToList();
            int pokemonIndex = this.randomNumberGenerator.Next(0, alivePlayerPokemons.Count);

            if (AllPokemonsDead(alivePlayerPokemons.Count))
            {
                this.duelEnded = true;
                GameData.currentEnemy = null;
                ShowBattleResult("loss");

                return;
            }

            this.playerActivePokemon = alivePlayerPokemons[pokemonIndex];
            DrawPokemon(this.playerPokemonImage, ((Pokemon)this.playerActivePokemon).PokemonImagePathBack);
            UpdatePlayerStats();
            UpdateButtonsSkillNames();
        }

        private void EnemySelectPokemon()
        {
            var aliveEnemyPokemons = GameData.currentEnemy.Pokemons.Where(p => p.IsAlive).ToList();
            int pokemonIndex = this.randomNumberGenerator.Next(0, aliveEnemyPokemons.Count);

            if (AllPokemonsDead(aliveEnemyPokemons.Count))
            {
                this.duelEnded = true;
                GameData.npcs.Remove(GameData.currentEnemy);
                GameData.currentEnemy = null;
                ShowBattleResult("win");

                return;
            }

            this.enemyActivePokemon = aliveEnemyPokemons[pokemonIndex];
            DrawPokemon(this.enemyPokemonImage, ((Pokemon)this.enemyActivePokemon).PokemonImagePathFront);
            UpdateEnemyStats();
        }

        private void DrawPokemon(GameObject imagePlaceholder, string imagePath)
        {
            UITexture texture = imagePlaceholder.GetComponent<UITexture>();
            texture.mainTexture = (Texture2D)Resources.Load(imagePath);
            texture.depth = 3;
            texture.MakePixelPerfect();
        }

        private void UpdatePlayerStats()
        {
            this.playerPokemonNameLabel.text = this.playerActivePokemon.GetType().Name;
            this.playerPokemonLevelLabel.text = string.Format("Lvl. {0:00}", this.playerActivePokemon.CurrentLevel);
            this.playerPokemonHealthLabel.text = this.playerActivePokemon.CurrentHealth + "/" + this.playerActivePokemon.MaxHealth;
            this.playerHealthBar.value = (float)this.playerActivePokemon.CurrentHealth / this.playerActivePokemon.MaxHealth;
        }

        private void UpdateEnemyStats()
        {
            this.enemyPokemonNameLabel.text = this.enemyActivePokemon.GetType().Name;
            this.enemyPokemonLevelLabel.text = string.Format("Lvl. {0:00}", this.enemyActivePokemon.CurrentLevel);
            this.enemyHealthBar.value = (float)this.enemyActivePokemon.CurrentHealth / this.enemyActivePokemon.MaxHealth;
        }
        
        private bool AllPokemonsDead(int alivePokemons)
        {
            if (alivePokemons == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ShowNotification()
        {
            this.notificationPopup.SetActive(true);
            DisableButtons();
        }

        private void ShowActionResult(string resultToShow)
        {
            this.actionResultLabel.gameObject.SetActive(true);
            this.actionResultLabel.text = resultToShow;
        }

        public void EnableButtons()
        {
            GameObject buttonsContainer = this.firstSpecialButton.transform.parent.gameObject;

            foreach (Transform button in buttonsContainer.transform)
            {
                button.GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        private void DisableButtons()
        {
            GameObject buttonsContainer = this.firstSpecialButton.transform.parent.gameObject;
            foreach (Transform button in buttonsContainer.transform)
            {
                button.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        private void UpdateButtonsSkillNames()
        {
            this.specialActionsButtons.SetActive(true);
            this.firstSpecialButton.GetComponentInChildren<UILabel>().text =
                this.playerActivePokemon.Abilities[0].GetType().Name;
            this.secondSpecialButton.GetComponentInChildren<UILabel>().text =
                this.playerActivePokemon.Abilities[1].GetType().Name;
            this.thirdSpecialButton.GetComponentInChildren<UILabel>().text =
                this.playerActivePokemon.Abilities[2].GetType().Name;
            this.fourthSpecialButton.GetComponentInChildren<UILabel>().text =
                this.playerActivePokemon.Abilities[3].GetType().Name;
            this.specialActionsButtons.SetActive(false);
        }

        private void EnemyExecuteTurn()
        {
            bool hasAvailableAbilities = true;
            var availableAbilities = this.enemyActivePokemon.Abilities
                .Where(a => ((SpecialAbility)a).CurrentCooldown == 0)
                .ToList();

            if (availableAbilities.Count == 0)
            {
                hasAvailableAbilities = false;
            }

            if (hasAvailableAbilities)
            {
                int normalOrSpecialAttack = this.randomNumberGenerator.Next(1, 11);
                if (normalOrSpecialAttack > 7)
                {
                    EnemyDoSpecialAbility(availableAbilities);
                }
                else
                {
                    EnemyDoNormalAttack();
                }                
            }
            else
            {
                EnemyDoNormalAttack();
            }

            this.enemyUsedAbility = true;
        }

        private void EnemyDoNormalAttack()
        {
            this.playerActivePokemon.CurrentHealth -= this.enemyActivePokemon.AttackDamage;
            UpdatePlayerStats();

            this.actionMessage = string.Format("Enemy's {0} hit player's {1} for {2} Damage.",
                this.enemyActivePokemon.GetType().Name, this.playerActivePokemon.GetType().Name,
                this.enemyActivePokemon.AttackDamage);
            ShowActionResult(this.actionMessage);

            if (this.playerActivePokemon.CurrentHealth <= 0)
            {
                this.playerActivePokemon.IsAlive = false;
                PlayerSelectPokemon();
            }
        }

        private void EnemyDoSpecialAbility(IList<IAbility> availableAbilities)
        {
            int abilityIndex = this.randomNumberGenerator.Next(0, availableAbilities.Count);
            SpecialAbility usedAbility = (SpecialAbility)availableAbilities[abilityIndex];

            if (SpecialAbility.TargetIsHit(usedAbility))
            {
                this.actionMessage = usedAbility.HitMessage;
                this.actionMessage = this.actionMessage.Replace("enemy", "player");

                if (usedAbility.GetType().BaseType == typeof(DamageAbility))
                {
                    this.actionMessage += string.Format(" The target suffers {0} damage.", usedAbility.AbilityPower);
                    ((DamageAbility)usedAbility).Hit(this.playerActivePokemon);

                    if (this.playerActivePokemon.CurrentHealth <= 0)
                    {
                        this.playerActivePokemon.IsAlive = false;
                        PlayerSelectPokemon();
                    }
                }
                else if (usedAbility.GetType().BaseType == typeof(HealAbility))
                {
                    this.actionMessage += string.Format(" The target recieves {0} health.", usedAbility.AbilityPower);
                    ((HealAbility)usedAbility).Heal(this.enemyActivePokemon);
                }
            }
            else
            {
                this.actionMessage = usedAbility.MissMessage;
            }

            usedAbility.CurrentCooldown = usedAbility.BaseCooldown;
            ShowActionResult(this.actionMessage);
            UpdatePlayerStats();
            UpdateEnemyStats();
        }

        private void DecreaseAbilityCooldowns(IPokemon pokemon)
        {
            foreach (var ability in pokemon.Abilities)
            {
                SpecialAbility currentAbility = (SpecialAbility)ability;
                if (currentAbility.CurrentCooldown > 0)
                {
                    currentAbility.CurrentCooldown -= 1;
                }
            }
        }

        private void ShowBattleResult(string result)
        {
            this.fightResultPopup.SetActive(true);
            if (result.Equals("win"))
            {
                this.fightResultPopup.GetComponentInChildren<UILabel>().text = "YOU WON! Click me to get back to the world.";
            }
            else if (result.Equals("loss"))
            {
                this.fightResultPopup.GetComponentInChildren<UILabel>().text =
                    "You lost. Don't forget to get your revenge next time. Click me to get back to the world.";
            }
        }

        public void BackToWorld()
        {
            Application.LoadLevel("MainWorld");
        }
    }
}