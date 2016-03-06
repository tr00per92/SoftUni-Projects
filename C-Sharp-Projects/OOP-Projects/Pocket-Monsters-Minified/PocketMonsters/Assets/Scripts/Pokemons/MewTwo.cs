namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class MewTwo : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/mewtwo-front";
        private const string BackSideImagePath = "Pokemons/mewtwo-back";
        private const int NormalAttack = 6;
        private const int Level = 10;
        private const int Health = 48;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new SandStorm(),
                new GlacialStorm(),
                new Eruption(),
                new Balefrost()
            };

        public MewTwo() :
            base(Health, Level, NormalAttack, PokemonType.Frost,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
