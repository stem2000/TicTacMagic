using MEC;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class Gem : TileEffect {
        public override bool IsMoveBlocker() {
            return false;
        }

        public override void Run() {
            Timing.RunCoroutine(_DelayedDisable().CancelWith(gameObject));
        }
    }
}
