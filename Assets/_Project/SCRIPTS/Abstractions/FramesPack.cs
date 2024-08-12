using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [Serializable]
    public class FramesPack<T>
    {
        public float initialDelay;
        public List<T> frames;
    }
}
