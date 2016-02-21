namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Pikachu : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/pikachu-front";
        private const string BackSideImagePath = "Pokemons/pikachu-back";
        private const int NormalAttack = 3;
        private const int Level = 1;
        private const int Health = 44;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Aftershock(),
                new Lightning(),
                new Thundershock(),
                new Recharge()
            };

        public Pikachu() :
            base(Health, Level, NormalAttack, PokemonType.Lightning,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
