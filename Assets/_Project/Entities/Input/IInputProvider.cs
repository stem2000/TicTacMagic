using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacMagic
{
    public interface IInputProvider
    {
        public MoveDirection GetMoveDirection();
    }
}
