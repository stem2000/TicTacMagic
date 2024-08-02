using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace TicTacMagic
{
    public abstract class TileObject : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }
        public abstract bool IsMoveBlocker();
        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }
        public virtual IEnumerator<float> _StartDestroing(float lifetime)
        {
            yield return Timing.WaitForSeconds(lifetime);
            Destroy(gameObject);
        }
    }
}
