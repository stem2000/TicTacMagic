using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace TicTacMagic
{
    public class BoundsPromter : MonoBehaviour
    {
        [SerializeField] float bottomBound;
        [SerializeField] float rightBound;
        [SerializeField] float leftBound;        
        [SerializeField] float topBound;

        private static BoundsPromter instance;

        public static BoundsPromter Instance => instance;

        public bool IsOutsideHorizonatalBounds(Projectile projectile)
        {
            var projectilePosition = projectile.transform.position;

            if (projectilePosition.x <= leftBound || projectilePosition.x >= rightBound)
                return true;

            return false;
        }

        public bool IsOutsideVerticalBounds(Projectile projectile)
        {
            var projectilePosition = projectile.transform.position;

            if (projectilePosition.y <= bottomBound || projectilePosition.y >= topBound)
                return true;

            return false;
        }

        public bool IsOutsideBounds(Projectile projectile)
        {
            if(IsOutsideHorizonatalBounds(projectile) || IsOutsideVerticalBounds(projectile))
                return true;
            return false;
        }

        private void Awake()
        {
            if (instance == null) instance = this;
            else
                if (instance != this) Destroy(gameObject);
        }
    }
}
