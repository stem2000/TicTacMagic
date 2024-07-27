using UnityEngine;

namespace TicTacMagic
{
    public interface IPlayer
    {
        public Vector2 CurrentTilePosition { get; }
        public Vector2 RealBodyPosition { get; }

        public bool IsOnCurrentTile { get;}
    }
}