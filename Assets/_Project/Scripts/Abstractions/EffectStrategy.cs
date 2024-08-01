using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class EffectStrategy : MonoBehaviour
    {
        protected bool readyToSpawn;
        protected IPlayer player;        
        public bool ReadyToSpawn => readyToSpawn;


        public abstract void Spawn();
        protected abstract IEnumerator<float> SpawnerReset();
    }
}