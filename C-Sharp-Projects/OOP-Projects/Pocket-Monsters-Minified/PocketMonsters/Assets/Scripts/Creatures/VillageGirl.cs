namespace Creatures
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class VillageGirl : FriendlyNpc
    {
        public const string NpcPrefabPath = "Prefabs/VillagerGirl";

        public VillageGirl(float posX, float posY, float posZ, GameObject objectOnField, string[] dialogueLines = null)
            : base(posX, posY, posZ, objectOnField, NpcPrefabPath, dialogueLines)
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
