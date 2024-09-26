using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private TileField tileField;

        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private PlayerSpawner playerSpawner;


        public override void InstallBindings() {
            this.Container
                .BindInstance(this.tileField)
                .AsSingle();

            this.Container
                .BindInstance(this.gameManager)
                .AsSingle();

            this.Container
                .BindInstance(this.playerSpawner)
                .AsSingle();

            this.Container
                .Bind<IInputProvider>()
                .To<InputActionsWrapper>()
                .AsSingle();
        }
    }
}
