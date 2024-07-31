using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace TicTacMagic
{
    public abstract class TileObject : MonoBehaviour
    {
        public abstract bool IsMoveBlocker();
    }
}
