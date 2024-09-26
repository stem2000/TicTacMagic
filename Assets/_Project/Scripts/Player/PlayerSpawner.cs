using System;
using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class PlayerSpawner : MonoBehaviour
    {
        public event Action<Player> OnPlayerSpawned;

        [SerializeField] 
        private Player playerPrefab;

        private TileField tileField;
        private IInputProvider inputProvider;


        [Inject]
        public void Construct(DiContainer container) {
            this.tileField = container.Resolve<TileField>();
            this.inputProvider = container.Resolve<IInputProvider>();
        }

        private void Start() {
            SpawnPlayer(new InputActionsWrapper());
        }

        private void SpawnPlayer(IInputProvider inputProvider)
        {
            Player.PlayerBuilder playerBuilder = new Player.PlayerBuilder();

            playerBuilder
                .InsantiatePlayer(this.playerPrefab, this.tileField.GetRandomTile())
                .SetTileField(this.tileField)
                .SetInputProvider(this.inputProvider);

            OnPlayerSpawned?.Invoke(playerBuilder.GetInstance());
        }
    }
}
