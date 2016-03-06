namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Bulbasaur : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/bulbasaur-front";
        private const string BackSideImagePath = "Pokemons/bulbasaur-back";
        private const int Health = 38;
        private const int Level = 1;
        private const int NormalAttack = 5;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Eruption(),
                new Cataclysm(),
                new SandStorm(),
                new Aftershock()
            };

        public Bulbasaur() :
            base(Health, Level, NormalAttack, PokemonType.Grass,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
