namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Nidoqueen : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/nidoqueen-front";
        private const string BackSideImagePath = "Pokemons/nidoqueen-back";
        private const int NormalAttack = 6;
        private const int Level = 3;
        private const int Health = 45;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Eruption(),
                new Recharge(),
                new Firebreath(),
                new Cataclysm()
            };

        public Nidoqueen() :
            base(Health, Level, NormalAttack, PokemonType.Earth,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
