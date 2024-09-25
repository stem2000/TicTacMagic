using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class EffectMarker : MonoBehaviour
    {
        public IEnumerator<float> _StayOnSpot(float duration, Vector2 position)
        {
            transform.position = position;
            yield return Timing.WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}