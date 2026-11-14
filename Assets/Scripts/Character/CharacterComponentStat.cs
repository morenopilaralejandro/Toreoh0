using Aremoreno.Enums.Character;
using Aremoreno.Enums.Duel;
using Aremoreno.Enums.Move;

public class CharacterComponentStat
{
    private Character character;

    public CharacterComponentStat(CharacterData data, Character character)
    {
        this.character = character;
    }

    public Stat GetStatByDuelRoleAndMoveCategory(DuelRole duelRole, MoveCategory moveCategory) 
    {
        if (duelRole == DuelRole.Offense) 
        {
            if (moveCategory == MoveCategory.Range)
                return Stat.RangeAttack;
            else
                return Stat.MeleeAttack;
        } else 
        {
            if (moveCategory == MoveCategory.Range)
                return Stat.RangeDefense;
            else
                return Stat.MeleeDefense;
        }
    }

    public float GetStatValueByDuelRoleAndMoveCategory(DuelRole duelRole, MoveCategory moveCategory) 
    {
        // call GetStatByDuelRoleAndMoveCategory(duelRole, moveCategory);
        return 1f;
    }
}
