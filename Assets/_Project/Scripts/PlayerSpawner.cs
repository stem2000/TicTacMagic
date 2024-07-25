using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] List<Tile> tiles;
        [SerializeField] Player playerPrefab;

        public void SpawnPlayer()
        {
            var tileNumber = Random.Range(0, tiles.Count - 1);
            var player = Instantiate(playerPrefab, tiles[tileNumber].GetPosition(), Quaternion.identity);

            player.CurrentTile = tiles[tileNumber];
        }
    }
}
