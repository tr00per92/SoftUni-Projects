namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Kadabra : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/kadabra-front";
        private const string BackSideImagePath = "Pokemons/kadabra-back";
        private const int NormalAttack = 3;
        private const int Level = 3;
        private const int Health = 45;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Frostbolt(),
                new Balefrost(),
                new GlacialStorm(),
                new Recharge()
            };

        public Kadabra() :
            base(Health, Level, NormalAttack, PokemonType.Lightning,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
