using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class TileObject : MonoBehaviour
    {
        public abstract bool IsMoveBlocker();
    }
}
