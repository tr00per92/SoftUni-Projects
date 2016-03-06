namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Meowth : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/meowth-front";
        private const string BackSideImagePath = "Pokemons/meowth-back";
        private const int NormalAttack = 6;
        private const int Level = 1;
        private const int Health = 46;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Thundershock(),
                new Frostbolt(),
                new Recharge(),
                new Flamestrike()
            };

        public Meowth() :
            base(Health, Level, NormalAttack, PokemonType.Lightning,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
