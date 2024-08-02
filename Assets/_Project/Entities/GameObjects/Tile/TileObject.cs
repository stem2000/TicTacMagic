using System.Collections.Generic;
using UnityEngine;
using MEC;

namespace TicTacMagic
{
    public abstract class TileObject : MonoBehaviour
    {
        public abstract bool IsMoveBlocker();
        public virtual IEnumerator<float> StartDestroing(float lifetime)
        {
            yield return Timing.WaitForSeconds(lifetime);
            Destroy(gameObject);
        }
    }
}
