using Aremoreno.Enums.Character;

public class WinConditionLastStandingUser : WinCondition
{
    private int countCharactersSideOther;
    private int countCharactersSideUser;

    public override bool CheckCondition() 
    {
        countCharactersSideOther = 0;
        countCharactersSideUser = 0;

        foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
            foreach(CharacterEntityBattle entity in team.TeamComponentCharacter.ListCharacterPointEntity) 
                if (entity.Character.CharacterComponentStats.StatsBattle.Get(Stat.Hp) > 0) // alive
                {
                    if (entity.Character.CharacterComponentSide.IsSameTeam(battle.BattleComponentTeam.BattleSideUser))
                        countCharactersSideUser++;
                    else 
                        countCharactersSideOther++;
                }

        return countCharactersSideUser == 0 || countCharactersSideOther == 0;
    }
}


    /*
    there can be up two characters alive for each team
    some teams can have 0 characters

    example
        north 1 alive
        south 2 alive
        east 0  alive

    other side == 0
    user side = 0
    double condition to end game
    */
