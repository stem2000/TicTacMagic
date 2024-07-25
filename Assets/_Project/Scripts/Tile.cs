using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Tile up;
        [SerializeField] private Tile down;
        [SerializeField] private Tile left;
        [SerializeField] private Tile right;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public Tile GetLeftTile()
        {
            return left;
        }

        public Tile GetRightTile()
        {
            return right;
        }

        public Tile GetUpTile()
        {
            return up;
        }

        public Tile GetDownTile()
        {
            return down;
        }


    }
}
