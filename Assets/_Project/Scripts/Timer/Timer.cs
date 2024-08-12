using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float time;
        private UnityEvent OnTimeIsUp;
        private bool IsStopped = true;

        private void Update()
        {
            if(!IsStopped)
                UpdateTime();
        }

        public float GetTime()
        {
            return time;
        }

        public void ResetTimer(float time)
        {
            this.time = time;
            IsStopped = false;
        }

        private void UpdateTime() 
        {
            if(time != 0)
                CalculateTime();
            else
            {
                IsStopped = true;
                OnTimeIsUp?.Invoke();
            }
        }

        private void CalculateTime()
        {
            if (time > 0)
                time -= Time.deltaTime;
            else
                time = 0;
        }
    }
}
