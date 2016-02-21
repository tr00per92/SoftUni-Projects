namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Groudon : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/groudon-front";
        private const string BackSideImagePath = "Pokemons/groudon-back";
        private const int NormalAttack = 5;
        private const int Level = 3;
        private const int Health = 40;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new SuperNova(),
                new Thundershock(),
                new Firebreath(),
                new Armageddon()
            };

        public Groudon() :
            base(Health, Level, NormalAttack, PokemonType.Fire,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
