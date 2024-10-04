namespace TicTacMagic {
    public interface IEffect {
        public float Weight {get; }
        public bool Disabled { get;}
        public EffectType Type { get; }
    }
}
