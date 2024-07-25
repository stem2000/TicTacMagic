using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] PlayerSpawner playerSpawner;

        private void Start()
        {
            playerSpawner.SpawnPlayer();
        }
    }
}
