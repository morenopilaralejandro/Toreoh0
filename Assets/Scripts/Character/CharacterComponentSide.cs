using Aremoreno.Enums.Battle;

public class CharacterComponentSide
{
    public BattleSide BattleSide;
    public int EntityIndex;

    public CharacterComponentSide(CharacterData data) 
    {

    }

    public void SetBattleSide(BattleSide battleSide)
    {
        BattleSide = battleSide;
    }

    public void SetEntityIndex(int entityIndex)
    {
        EntityIndex = entityIndex;
    }

    public bool IsSameTeam(Character other) => IsSameTeam(BattleSide, other.CharacterComponentSide.BattleSide);
    public bool IsSameTeam(BattleSide otherSide) => IsSameTeam(BattleSide, otherSide);
    public bool IsSameTeam(BattleSide ownSide, BattleSide otherSide) 
    {
        switch (BattleManager.Instance.Battle.BattleComponentAttributes.BattleFormat)
        {
            case BattleFormat.Double:
                switch (ownSide)
                {
                    case BattleSide.North:
                        return otherSide == BattleSide.North || otherSide == BattleSide.West;
                    case BattleSide.West:
                        return otherSide == BattleSide.North || otherSide == BattleSide.West;
                    case BattleSide.South:
                        return otherSide == BattleSide.South || otherSide == BattleSide.East;
                    case BattleSide.East:
                        return otherSide == BattleSide.South || otherSide == BattleSide.East;
                }
                break;
            default:
                return ownSide == otherSide;
        }
        return false;
    }
}
