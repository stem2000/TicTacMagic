using MEC;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class EffectStrategy<T> : MonoBehaviour, IStrategy where T : Frame
    {
        protected bool readyToSpawn;
        protected IPlayer player;        
        protected List<T> frames;
        protected T frame;
        public float InitialDelay;
        public bool ReadyToSpawn => readyToSpawn;


        public abstract void Spawn();
        public virtual void RunInitialDelay()
        {
            Timing.RunCoroutine(_RunInitialDelay());
        }
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
                frame = this.frames[0];
            }
        }
        protected virtual IEnumerator<float> _RunFrameStartDelay()
        {
            yield return Timing.WaitForSeconds(frame.StartDelay);
        }
        protected virtual IEnumerator<float> _RunFrameEndDelay()
        {
            yield return Timing.WaitForSeconds(frame.EndDelay);
            ChangeFrame();
            readyToSpawn = true;
        }
        protected virtual IEnumerator<float> _RunInitialDelay()
        {
            yield return Timing.WaitForSeconds(InitialDelay);
            readyToSpawn = true;
        }

    }
}