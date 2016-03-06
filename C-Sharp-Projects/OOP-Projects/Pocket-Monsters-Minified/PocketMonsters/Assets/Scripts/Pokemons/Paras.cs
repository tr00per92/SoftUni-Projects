namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Paras : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/paras-front";
        private const string BackSideImagePath = "Pokemons/paras-back";
        private const int NormalAttack = 3;
        private const int Level = 1;
        private const int Health = 43;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new SuperNova(),
                new IceBlade(),
                new Eruption(),
                new GlacialStorm()
            };

        public Paras() :
            base(Health, Level, NormalAttack, PokemonType.Water,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
