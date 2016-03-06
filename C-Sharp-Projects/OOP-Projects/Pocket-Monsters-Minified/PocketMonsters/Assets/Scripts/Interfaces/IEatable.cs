namespace Interfaces
{
    using System.Collections.Generic;

    public interface IEatable
    {
        void Feed(IList<IPokemon> pokemons);
    }
}
