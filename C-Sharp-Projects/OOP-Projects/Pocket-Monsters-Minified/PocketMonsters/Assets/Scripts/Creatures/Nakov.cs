namespace Creatures
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;
    using Interfaces;
    using Pokemons;

    public class Nakov : EnemyNpc
    {
        public const string NpcPrefabPath = "Prefabs/Nakov";
        private static readonly IList<IPokemon> NakovPokemons =
            new List<IPokemon>
            {
                new MewTwo(),
                new Charizard(),
                new Snorlax()
            };

        public Nakov(float posX, float posY, float posZ, GameObject objectOnField, string[] dialogueLines = null)
            : base(posX, posY, posZ, NakovPokemons, objectOnField, NpcPrefabPath, dialogueLines)
        { }

        public override void Talk()
        {
            GameObject chatBubble = this.NpcObject.transform.Find("ChatBubble").gameObject;
            if (!chatBubble.activeInHierarchy)
            {
                chatBubble.SetActive(true);
                var randomGenerator = new System.Random();
                int randomDialogueIndex = randomGenerator.Next(0, this.DialogueLines.Length);
                chatBubble.GetComponentInChildren<TextMesh>().text = this.DialogueLines[randomDialogueIndex];
            }
        }

        public override void StopTalking()
        {
            this.NpcObject.transform.Find("ChatBubble").gameObject.SetActive(false);
        }
    }
}
