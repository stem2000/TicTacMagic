using UnityEditor;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class SpawnStrategy : ScriptableObject
    {
        protected bool readyToSpawn;
        protected IPlayer player;
        public bool ReadyToSpawn => readyToSpawn;


        public abstract void Spawn();
    }
}