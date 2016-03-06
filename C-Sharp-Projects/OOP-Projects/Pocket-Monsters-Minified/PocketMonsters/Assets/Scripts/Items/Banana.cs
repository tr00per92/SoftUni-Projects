namespace Items
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using UnityEngine;

    public struct Banana : IEatable, IDrawable
    {
        public const string ItemPrefabPath = "Prefabs/Banana";

        public Banana(int foodAmount)
            : this()
        {
            this.FoodAmount = foodAmount;
        }

        public GameObject Item
        {
            get;
            private set;
        }

        public int FoodAmount
        {
            get;
            private set;
        }

        public void Feed(IList<IPokemon> pokemons)
        {
            foreach (var pokemon in pokemons)
            {
                pokemon.CurrentHealth = pokemon.MaxHealth;
                pokemon.IsAlive = true;
            }
        }

        public void Draw(float posX, float posY, float posZ, string prefabPath)
        {
            GameObject bananaObject = (GameObject)GameObject.Instantiate(Resources.Load(prefabPath, typeof(GameObject)));
            bananaObject.transform.position = new Vector3(posX, posY, posZ);
            bananaObject.tag = "foodItem";
            this.Item = bananaObject;
        }
    }
}
