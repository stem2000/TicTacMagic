using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TileField : MonoBehaviour
    {
        private List<Tile> tiles;

        private void Awake() {
            this.tiles = GetComponentsInChildren<Tile>(true).ToList();
        }

        public Tile GetTileClosestTo(Vector2 position)
        {
            var minDistance = (this.tiles[0].GetPosition() - position).magnitude;
            var result = this.tiles[0];

            foreach(var tile in this.tiles)
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


        public Tile GetRandomTile() {
            var tileNumber = Random.Range(0, this.tiles.Count - 1);

            return this.tiles[tileNumber];
        }


        public List<Tile> GetTiles() 
        {
            return tiles;
        }
    }
}
