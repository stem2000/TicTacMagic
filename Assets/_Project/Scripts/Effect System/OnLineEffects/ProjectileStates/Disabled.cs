using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class Disabled : IState {
        private Projectile _projectile;

        public Disabled(Projectile projectile) {
            _projectile = projectile;
        }

        public void OnEnter() {
            _projectile.KillRoutines();
        }

        public void OnExit() {

        }

        public void Tick() {
            
        }
    }
}
