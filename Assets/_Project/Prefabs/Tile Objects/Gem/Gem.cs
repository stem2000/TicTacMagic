using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public class Gem : TileEffect
    {
        public static UnityEvent OnCollect = new UnityEvent();

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
