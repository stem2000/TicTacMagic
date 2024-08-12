using MEC;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace TicTacMagic
{
    public class Marker : MonoBehaviour
    {
        public IEnumerator<float> _StayOnSpot(float duration, Vector2 position)
        {
            transform.position = position;
            yield return Timing.WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}