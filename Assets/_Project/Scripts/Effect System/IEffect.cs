namespace TicTacMagic {
    public interface IEffect {
        public float Weight {get; }
        public bool Active { get;}
        public EffectType Type { get; }

        public abstract void Run();
    }
}
