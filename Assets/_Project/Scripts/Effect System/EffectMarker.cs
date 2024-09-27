using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class EffectMarker : MonoBehaviour
    {
        [SerializeField]
        private float showTime;
        public IEnumerator<float> _ShowMarker() {
            this.gameObject.SetActive(true);
            yield return Timing.WaitForSeconds(this.showTime);
            this.gameObject.SetActive(false);
        }
    }
}