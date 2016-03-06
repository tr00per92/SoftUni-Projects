namespace Interfaces
{
    using System.Collections.Generic;

    public interface IPokemonTrainer
    {
        IList<IPokemon> Pokemons { get; }
    }
}
