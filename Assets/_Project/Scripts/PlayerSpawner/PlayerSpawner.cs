using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] Player playerPrefab;

        public IPlayer SpawnPlayer(IDirectionProvider inputProvider)
        {
            var tiles = FindObjectsByType<Tile>(FindObjectsSortMode.None).ToList();
            var tileNumber = Random.Range(0, tiles.Count - 1);
            var player = Instantiate(playerPrefab, tiles[tileNumber].GetPosition(), Quaternion.identity);

            player.Initialize(tiles[tileNumber], inputProvider);

            return player;
        }
    }
}
