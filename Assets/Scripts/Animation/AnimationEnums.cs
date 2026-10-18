namespace Aremoreno.Enums.Animation
{
    public enum CharacterAnimationEntryDirection 
    {
        FourDirections,
        DownOnly
    }

    public enum AnimationPriority 
    {
        Low = 0,
        Medium = 1,
        High = 2
    }

    public enum CharacterAnimationState 
    {
        Idle = 0,
        Walk = 1,
        Run = 2,
        Jump = 3,
        Combat = 4,
        Emote = 5,
        Slash = 6,
        Taunt = 7,
        Spellcast = 8,
        Special = 9,
        Transform = 10,
        Wing = 11
    }

    public enum CharacterDirection
    {
        Down = 0,
        Up = 1,
        Left = 2,
        Right = 3
    }

    public enum AnimationFacingMode 
    {
        Transform,
        Formation,
        ActionOverride,
        DownOnly
    }
}
