using MEC;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace TicTacMagic
{
    public class TileMarker : MonoBehaviour
    {
        public IEnumerator<float> _StayOnTile(float duration, Vector2 position)
        {
            transform.position = position;
            yield return Timing.WaitForSeconds(duration);
            Destroy(gameObject);
        }
    }
}