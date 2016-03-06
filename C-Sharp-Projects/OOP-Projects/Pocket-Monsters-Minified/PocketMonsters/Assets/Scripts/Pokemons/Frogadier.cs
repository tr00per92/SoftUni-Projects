namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Frogadier : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/frogadier-front";
        private const string BackSideImagePath = "Pokemons/frogadier-back";
        private const int NormalAttack = 5;
        private const int Level = 2;
        private const int Health = 38;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Thundershock(),
                new Firebreath(),
                new Aftershock(),
                new Frostbolt()
            };

        public Frogadier() :
            base(Health, Level, NormalAttack, PokemonType.Water,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
