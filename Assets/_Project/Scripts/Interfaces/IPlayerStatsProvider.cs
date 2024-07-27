namespace TicTacMagic
{
    public interface IPlayerStatsProvider
    {
        public float Speed { get;}
        public float Hp { get; }
        public float DistanceToTileChange { get; }
    }
}