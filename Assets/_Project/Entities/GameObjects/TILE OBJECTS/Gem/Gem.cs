using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class Gem : TileObject
    {
        public static UnityEvent OnCollect;

        public override bool IsMoveBlocker()
        {
            return false;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.GetComponent<Player>() != null)
                OnCollect?.Invoke();
            Destroy(gameObject);
        }
    }
}
