namespace Interfaces
{
    using System;
    using Abilities;

    public interface IAbility
    {
        int AbilityPower { get; }
        AbilityType Type { get; }
    }
}
