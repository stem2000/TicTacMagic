using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class OneStonePerTime : EffectStrategy
    {
        [SerializeField] Stone stone;
        public override void Spawn()
        {
            
        }

        protected override IEnumerator<float> SpawnerReset()
        {
            throw new System.NotImplementedException();
        }
    }
}
