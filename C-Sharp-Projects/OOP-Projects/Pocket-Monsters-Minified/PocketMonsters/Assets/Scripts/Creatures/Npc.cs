namespace Creatures
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using UnityEngine;
    using Common;

    public abstract class Npc : GameElement
    {
        private GameObject npc;
        private string prefabPath;

        protected Npc(GameObject objectOnField, string prefabPath, string[] dialogueLines)
        {
            this.NpcObject = objectOnField;
            this.PrefabPath = prefabPath;
            this.DialogueLines = dialogueLines;
        }

        public GameObject NpcObject
        {
            get { return this.npc; }
            set { this.npc = value; }
        }

        public string PrefabPath
        {
            get { return this.prefabPath; }
            private set { this.prefabPath = value; }
        }

        public string[] DialogueLines { get; protected set; }
    }
}
