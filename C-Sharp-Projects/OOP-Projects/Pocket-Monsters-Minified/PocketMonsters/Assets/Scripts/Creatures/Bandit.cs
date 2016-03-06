namespace Creatures
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;
    using Interfaces;
    using Pokemons;

    public class Bandit : EnemyNpc
    {
        public const string NpcPrefabPath = "Prefabs/Bandit";
        private static readonly IList<IPokemon> BanditPokemons =
            new List<IPokemon>
            {
                new Rattata(),
                new Squirtle(),
                new Nidoqueen()
            };

        public Bandit(float posX, float posY, float posZ, GameObject objectOnField, string[] dialogueLines = null)
            : base(posX, posY, posZ, BanditPokemons, objectOnField, NpcPrefabPath, dialogueLines)
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
