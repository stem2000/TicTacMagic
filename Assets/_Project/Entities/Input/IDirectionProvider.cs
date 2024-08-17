using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacMagic
{
    public interface IDirectionProvider
    {
        public MoveDirection GetMoveDirection();
    }
}
