using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class OneStonePerTime : EffectStrategy
    {
        [SerializeField] 
        public override void Spawn()
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerator<float> SpawnerReset()
        {
            throw new System.NotImplementedException();
        }
    }
}
