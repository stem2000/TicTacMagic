using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] List<Tile> tiles;
        [SerializeField] Player player;

        public void SpawnPlayer()
        {
            int tileNumber = Random.Range(0, tiles.Count - 1);
            Instantiate(player, tiles[tileNumber].GetPosition(), Quaternion.identity);
        }
    }
}
