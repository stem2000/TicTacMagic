using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace TicTacMagic
{
    public class BoundsPromter : MonoBehaviour
    {
        private float bottomBound;
        private float rightBound;
        private float leftBound;
        private float topBound;

        private static BoundsPromter instance;

        public static BoundsPromter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<BoundsPromter>();

                    if (instance == null)
                    {
                        GameObject boundsPromter = new GameObject();
                        instance = boundsPromter.AddComponent<BoundsPromter>();
                        boundsPromter.name = typeof(BoundsPromter).ToString() + " (Singleton)";

                        DontDestroyOnLoad(boundsPromter);
                    }
                }
                return instance;
            }
        }

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
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this) 
                Destroy(gameObject);
        }

        public void Initialize(float top, float bottom, float left, float right)
        {
            topBound = top;
            bottomBound = bottom;
            leftBound = left;
            rightBound = right;
        }
    }
}
