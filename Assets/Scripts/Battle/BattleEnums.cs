namespace Aremoreno.Enums.Battle
{
    public enum BattleType
    {
        Full,
        Mini
    }

    public enum BattleFormat
    {
        Single,
        Double,
        FreeForAll
    }

    public enum BattleGamemode 
    {
        Singleplayer,
        Multiplayer
    }

    public enum BattleMessage
    {
        Start,
        Finish
    }

    public enum BattleSide 
    {
        South,
        North,
        West,
        East
    }

    /* 
        in 1 vs 1
        home -> south
        away -> north

        in 2 vs 2 
        home -> south, east
        away -> north, west
    */

    public enum BattleState
    {
        Idle,
        Processing,
        InCutscene,
        Paused,
        Ended
    }

    public enum BattlePhase
    {
        Varas,
        Banderillas,
        Muerte,
        Capture
    }

    public enum ProtectObstacleState
    {
        Allright,
        Damaged,
        Wrecked
    }

    public enum BarrierType 
    {
        LineMedium
    }
}
