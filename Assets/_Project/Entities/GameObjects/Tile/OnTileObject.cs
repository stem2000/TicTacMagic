using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class OnTileObject : MonoBehaviour
    {
        public abstract bool IsMoveCloser();
    }
}
