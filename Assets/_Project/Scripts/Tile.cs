using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Tile top;
        [SerializeField] private Tile bottom;
        [SerializeField] private Tile left;
        [SerializeField] private Tile right;

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}
