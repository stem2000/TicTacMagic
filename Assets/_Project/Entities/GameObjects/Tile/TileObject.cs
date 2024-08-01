using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class TileObject : MonoBehaviour
    {
        public abstract bool IsMoveBlocker();
        public abstract IEnumerator<float> StartDestroing(float lifetime);
    }
}
