using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptables/PlayerStats")]
    public class PlayerModel : ScriptableObject
    {
        public float Hp;
        public float Speed;
    }
}
