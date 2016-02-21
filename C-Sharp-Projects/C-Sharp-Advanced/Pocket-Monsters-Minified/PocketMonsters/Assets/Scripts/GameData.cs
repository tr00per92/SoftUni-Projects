namespace Scripts
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;
    using Common;
    using Creatures;
    using Items;
    using Pokemons;
    using Interfaces;

    public static class GameData
    {
        public static EnemyNpc currentEnemy;
        public static Hero player;
        public static IList<Npc> npcs;
        public static IList<IEatable> items;
    }
}
