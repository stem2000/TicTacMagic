using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public interface INonTargetStrategy
    {
        public void SetupStrategy(Transform spawnPosition);
    }
}
