using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] 
        private Player playerPrefab;

        private TileField tileField;

        [Inject]
        public void Construct(TileField tileField) {
            this.tileField = tileField;
        }

        private void Start() {
            SpawnPlayer(new InputActionsWrapper());
        }

        public void SpawnPlayer(IInputProvider inputProvider)
        {
            Player.PlayerBuilder playerBuilder = new Player.PlayerBuilder();

            playerBuilder
                .InsantiatePlayer(playerPrefab, tileField.GetRandomTile())
                .SetTileField(tileField)
                .SetDefaultInputProvider();
        }
    }
}
