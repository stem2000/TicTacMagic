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
        public virtual void Initialize(IPlayer player)
        {
            this.player = player;
            readyToSpawn = true;
        }
    }
}