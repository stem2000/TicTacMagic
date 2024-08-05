using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class TilePromter : MonoBehaviour
    {
        private static TilePromter instance;
        private List<Tile> tiles;

        public static TilePromter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<TilePromter>();

                    if (instance == null)
                    {
                        GameObject tilePromter = new GameObject();
                        instance = tilePromter.AddComponent<TilePromter>();
                        tilePromter.name = typeof(TilePromter).ToString() + " (Singleton)";

                        DontDestroyOnLoad(tilePromter);
                    }
                }
                return instance;
            }
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

        public List<Tile> GetTiles() 
        {
            return tiles;
        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
                Destroy(gameObject);
        }

        public void Initialize()
        {
            tiles = FindObjectsByType<Tile>(FindObjectsSortMode.None).ToList();
        }
    }
}
