using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public abstract class EffectStrategyAbstractFactory : ScriptableObject
    {
        public abstract EffectStrategy Instantiate();
    }
}
