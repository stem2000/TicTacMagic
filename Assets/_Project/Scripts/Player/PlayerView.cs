using MEC;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TicTacMagic
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float damageHighlightDuration = 0.3f;
        [SerializeField] private Color damageHiglihghtColor = Color.red;
        private IPlayer player;        


        public void Initialize(IPlayer player)
        {
            this.player = player;
            player.AddListenerToPlayerDamaged(PlayDamageEffect);
        }

        private void PlayDamageEffect(float damage)
        {
            Timing.RunCoroutine(_DamageEffectRoutine().CancelWith(gameObject));
        }

        IEnumerator<float> _DamageEffectRoutine()
        {
            spriteRenderer.color = damageHiglihghtColor;
            yield return Timing.WaitForSeconds(damageHighlightDuration);
            spriteRenderer.color = Color.white;
        }

    }
}
