using UnityEngine;
using Zenject;

namespace TicTacMagic
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private TileField _tileField;

        public override void InstallBindings() {
            this.Container.
                BindInstance(this._tileField).
                AsSingle();
        }
    }
}
