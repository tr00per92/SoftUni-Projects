namespace Pokemons
{
    using System.Collections.Generic;
    using Abilities;
    using Interfaces;

    public class Charmander : Pokemon
    {
        private const string FrontSideImagePath = "Pokemons/charmander-front";
        private const string BackSideImagePath = "Pokemons/charmander-back";
        private const int NormalAttack = 5;
        private const int Level = 1;
        private const int Health = 40;
        private IList<IAbility> abilities =
            new List<IAbility>()
            {
                new Armageddon(),
                new Enflame(),
                new Firebreath(),
                new Flamestrike()
            };

        public Charmander() :
            base(Health, Level, NormalAttack, PokemonType.Fire,
            FrontSideImagePath, BackSideImagePath)
        {
            base.Abilities = this.abilities;
        }
    }
}
