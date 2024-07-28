using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TilePromter
    {
        List<Tile> tiles;
        
        public TilePromter() 
        {
            tiles = GameObject.FindObjectsByType<Tile>(FindObjectsSortMode.None).ToList();
        }

        public Tile GetClosestTo(Vector2 position)
        {
            var minDistance = (tiles[0].GetPosition() - position).magnitude;
            var result = tiles[0];

            foreach(var tile in tiles)
            {
                var distance = (tile.GetPosition() - position).magnitude;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    result = tile;
                }
            }

            return result;
        }
    }
}
