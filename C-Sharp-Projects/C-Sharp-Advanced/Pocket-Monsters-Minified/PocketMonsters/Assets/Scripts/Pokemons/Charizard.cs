namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Charizard : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/charizard-front";
        private const string BackSideImagePath = "Pokemons/charizard-back";
        private const int NormalAttack = 7;
        private const int Level = 3;
        private const int Health = 49;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Balefrost(),
                new GlacialStorm(),
                new Lightning(),
                new Recharge()
            };

        public Charizard() :
            base(Health, Level, NormalAttack, PokemonType.Fire,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
