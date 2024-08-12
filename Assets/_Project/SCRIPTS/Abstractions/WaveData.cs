using System;

namespace TicTacMagic
{
    [Serializable]
    public class WaveData<T> 
    {
        public int number;
        public FramesPack<T> framesPack;
    }
}
