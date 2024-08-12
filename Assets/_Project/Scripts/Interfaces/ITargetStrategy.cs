using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public interface ITargetStrategy
    {
        public void SetPlayer(IPlayer player);
    }
}
