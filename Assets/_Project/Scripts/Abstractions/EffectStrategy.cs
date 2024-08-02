using MEC;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class EffectStrategy<T> : MonoBehaviour, IStrategy
    {
        protected bool readyToSpawn;
        protected IPlayer player;        
        protected List<T> frames;
        protected T frame;
        public bool ReadyToSpawn => readyToSpawn;


        public abstract void Spawn();
        protected abstract IEnumerator<float> SpawnerReset();
        protected virtual void ChangeFrame()
        {
            var index = frames.IndexOf(frame);

            index = (index + 1 <= frames.Count - 1) ? index + 1 : 0;
            frame = frames[index];
        }
        public virtual void InitializeFrames(List<T> frames)
        {
            if(frames != null && frames.Count > 0)
            {
                this.frames = frames;
                frame = frames[0];
            }
        }
    }
}