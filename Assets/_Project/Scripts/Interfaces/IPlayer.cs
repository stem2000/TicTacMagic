using UnityEngine;
using UnityEngine.Events;

namespace TicTacMagic
{
    public interface IPlayer
    {
        public void AddListenerToPlayerDamaged(UnityAction<float> listener);
        public void AddListenerToPlayerDeath(UnityAction listener);
        public IPlayerStatsProvider PlayerStatsProvider { get; }
    }
}