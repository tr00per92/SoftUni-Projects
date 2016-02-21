namespace Creatures
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using UnityEngine;
    using Interfaces;

    public abstract class FriendlyNpc : Npc, ITalkable
    {
        private readonly string[] defaultDialogue = { "Hello", "How are you today" };

        public FriendlyNpc(float posX, float posY, float posZ, GameObject objectOnField, string prefabPath, string[] dialogueLines)
            : base(objectOnField, prefabPath, dialogueLines)
        {
            base.PositionX = posX;
            base.PositionY = posY;
            base.PositionZ = posZ;

            if (dialogueLines == null)
            {
                base.DialogueLines = this.defaultDialogue;
            }
        }

        public abstract void Talk();
        public abstract void StopTalking();
    }
}
