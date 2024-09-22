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
    }
}
