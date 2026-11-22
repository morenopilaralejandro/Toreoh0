namespace Aremoreno.Enums.Character
{
    public enum CharacterRole
    {
        Point,
        Assist
    }

    public enum Element
    {
        None,
        Fire,
        Ice,
        Holy,
        Evil,
        Wind,
        Forest,
        Earth,
        Electric,
        Water
    }

    public enum Stat
    {
        Hp,
        Mp,
        MeleeAttack,
        MeleeDefense,
        RangeAttack,
        RangeDefense,
        Speed
    }

    public enum ScalingStrategy
    {
        Linear,
        Exponential
    }

    public enum AIDifficulty
    {
        VeryEasy,
        Easy,
        Normal,
        Hard,
        VeryHard,
        Impossible
    }

    public enum CharacterState
    {
        Idle,
        Charge
    }

    public enum AIState
    {
        Idle,
        Bait,
        Attack,
        Turn,
        Move,
        Charge,
        Target
    }

    public enum AIBehaviour
    {
        Normal,
        Rage,
        Weak,
        Capture
    }

    public enum FatigueState 
    {
        Normal,
        Tired,
        Exhausted
    }

    public enum StatusEffectVolatile
    {
        None,
        Stunned
    }

    public enum StatusEffectPermanent
    {
        None,
        Fainted
    }
}
