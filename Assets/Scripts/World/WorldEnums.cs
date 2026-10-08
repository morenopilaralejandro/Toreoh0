namespace Aremoreno.Enums.World
{
    public enum ZoneType 
    {
        Overworld,
        Interior
    }

    public enum WorldState
    {
        Idle,
        Processing,
        InEncounter
    }

    public enum WorldStateCharacter
    {
        Freeroam,
        Processing,
        InEncounter,
        InMenu
    }

    public enum WorldTransitionTriggerState
    {
        Idle,
        CharacterInTrigger,
        Transitioning
    }
}
