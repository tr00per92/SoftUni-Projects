namespace Interfaces
{
    using System.Collections.Generic;
    using Pokemons;

    public interface IPokemon
    {
        int CurrentHealth { get; set; }
        
        int MaxHealth { get; }

        int CurrentLevel { get; }

        bool IsAlive { get; set; }

        bool CurrentlyActive { get; set; }

        int AttackDamage { get; }

        PokemonType Type { get; }

        IList<IAbility> Abilities { get; }

        void LearnAbility(IAbility ability);

        void ForgetAbility(IAbility ability);
    }
}
