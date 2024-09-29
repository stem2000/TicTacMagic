using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private TileField _tileField;

        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private UiManager _uiManager;

        [SerializeField]
        private PlayerSpawner _playerSpawner;


        public override void InstallBindings() {
            Container
                .BindInstance(_tileField)
                .AsSingle();

            Container
                .BindInstance(_gameManager)
                .AsSingle();

            Container
                .BindInstance(_uiManager)
                .AsSingle();

            Container
                .BindInstance(_playerSpawner)
                .AsSingle();

            Container
                .Bind<IInputProvider>()
                .To<InputActionsWrapper>()
                .AsSingle();
        }
    }
}
