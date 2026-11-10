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

    public bool IsSameTeam(Character other) 
    {
        switch (BattleManager.Instance.Battle.BattleComponentAttributes.BattleFormat)
        {
            case BattleFormat.Double:
                switch (BattleSide) 
                {
                    case BattleSide.North:
                        return other.CharacterComponentSide.BattleSide == BattleSide.North || other.CharacterComponentSide.BattleSide == BattleSide.West;
                    case BattleSide.West:
                        return other.CharacterComponentSide.BattleSide == BattleSide.North || other.CharacterComponentSide.BattleSide == BattleSide.West;
                    case BattleSide.South:
                        return other.CharacterComponentSide.BattleSide == BattleSide.South || other.CharacterComponentSide.BattleSide == BattleSide.East;
                    case BattleSide.East:
                        return other.CharacterComponentSide.BattleSide == BattleSide.South || other.CharacterComponentSide.BattleSide == BattleSide.East;
                }
                break;
            default:
                return BattleSide == other.CharacterComponentSide.BattleSide;
        }
        return false;
    }
}
