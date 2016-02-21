namespace Items
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Interfaces;

    public abstract class FoodItem : Item, IEatable
    {
        public FoodItem(GameObject objectOnField, string prefabPath)
            : base(objectOnField, prefabPath)
        { }

        public abstract void Feed(IList<IPokemon> pokemons);

        public override abstract void Draw();
    }
}
