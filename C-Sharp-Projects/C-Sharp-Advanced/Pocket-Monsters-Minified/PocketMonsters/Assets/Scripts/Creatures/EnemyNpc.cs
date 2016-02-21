namespace Creatures
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;
    using Interfaces;

    public abstract class EnemyNpc : Npc, IPokemonTrainer, ITalkable
    {
        private readonly string[] defaultDialogue = { "Here you are", "Let's fight" };

        public EnemyNpc(float posX, float posY, float posZ, IList<IPokemon> pokemons,
            GameObject objectOnField, string prefabPath, string[] dialogueLines = null)
            : base(objectOnField, prefabPath, dialogueLines)
        {
            base.PositionX = posX;
            base.PositionY = posY;
            base.PositionZ = posZ;

            this.Pokemons = pokemons;
            if (this.DialogueLines == null)
            {
                this.DialogueLines = this.defaultDialogue;
            }
        }

        public IList<IPokemon> Pokemons { get; private set; }

        public abstract void Talk();
        public abstract void StopTalking();
    }
}
