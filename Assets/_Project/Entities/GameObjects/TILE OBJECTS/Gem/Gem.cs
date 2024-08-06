using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Gem : TileObject
    {
        public override bool IsMoveBlocker()
        {
            return false;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(gameObject);
        }
    }
}
