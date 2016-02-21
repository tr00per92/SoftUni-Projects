namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Squirtle : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/squirtle-front";
        private const string BackSideImagePath = "Pokemons/squirtle-back";
        private const int NormalAttack = 3;
        private const int Level = 1;
        private const int Health = 43;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Balefrost(),
                new Frostbolt(),
                new GlacialStorm(),
                new Eruption()
            };

        public Squirtle() :
            base(Health, Level, NormalAttack, PokemonType.Water,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
