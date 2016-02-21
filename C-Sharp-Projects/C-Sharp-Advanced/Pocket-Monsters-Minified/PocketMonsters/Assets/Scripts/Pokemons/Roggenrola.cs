namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Roggenrola : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/roggenrola-front";
        private const string BackSideImagePath = "Pokemons/roggenrola-back";
        private const int NormalAttack = 4;
        private const int Level = 1;
        private const int Health = 40;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Flamestrike(),
                new Eruption(),
                new Lightning(),
                new Enflame()
            };

        public Roggenrola() :
            base(Health, Level, NormalAttack, PokemonType.Frost,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
