using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptables/PlayerStats")]
    public class PlayerStats : ScriptableObject, IPlayerStatsProvider
    {
        [SerializeField] public float hp;
        [SerializeField] public float speed;
        [SerializeField] public float distanceToTileChange;

        public float Speed { get {return speed; }}

        public float Hp { get { return hp; } }

        public float DistanceToTileChange { get { return distanceToTileChange; } }
    }
}
