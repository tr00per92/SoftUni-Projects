namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Rattata : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/rattata-front";
        private const string BackSideImagePath = "Pokemons/rattata-back";
        private const int NormalAttack = 4;
        private const int Level = 1;
        private const int Health = 41;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Firebreath(),
                new Cataclysm(),
                new Frostbolt(),
                new IceBlade()
            };

        public Rattata() :
            base(Health, Level, NormalAttack, PokemonType.Earth,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
