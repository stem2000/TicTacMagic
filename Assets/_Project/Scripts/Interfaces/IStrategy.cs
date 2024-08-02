namespace TicTacMagic
{
    public interface IStrategy
    {
        public bool ReadyToSpawn { get;}
        public abstract void Spawn();
    }
}