using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TilesPromter : MonoBehaviour
    {
        private static TilesPromter instance;
        private List<Tile> tiles;

        public static TilesPromter Instance => instance;

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

        private void Awake()
        {
            if (instance == null) instance = this;
            else
                if (instance != this) Destroy(gameObject);

            tiles = FindObjectsByType<Tile>(FindObjectsSortMode.None).ToList();
        }
    }
}
