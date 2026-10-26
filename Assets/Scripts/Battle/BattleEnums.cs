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
}
