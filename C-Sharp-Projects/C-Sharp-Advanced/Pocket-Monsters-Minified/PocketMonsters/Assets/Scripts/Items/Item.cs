namespace Items
{
    using System;
    using UnityEngine;

    public abstract class Item
    {
        private GameObject itemObject;
        private string prefabPath;

        public Item(GameObject objectOnField, string prefabPath)
        {
            this.ItemObject = objectOnField;
            this.PrefabPath = prefabPath;
        }

        public GameObject ItemObject
        {
            get { return this.itemObject; }
            set { this.itemObject = value; }
        }

        public string PrefabPath
        {
            get { return this.prefabPath; }
            private set { this.prefabPath = value; }
        }

        public abstract void Draw();
    }
}
