namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Snorlax : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/snorlax-front";
        private const string BackSideImagePath = "Pokemons/snorlax-back";
        private const int NormalAttack = 4;
        private const int Level = 2;
        private const int Health = 65;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new SuperNova(),
                new Armageddon(),
                new GlacialStorm(),
                new Cataclysm()
            };

        public Snorlax() :
            base(Health, Level, NormalAttack, PokemonType.Earth,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
