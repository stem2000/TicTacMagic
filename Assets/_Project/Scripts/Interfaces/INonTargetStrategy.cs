using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public interface INonTargetStrategy
    {
        public void Initiliaze(Transform spawnPosition, Vector2 spawnDirection);
    }
}
