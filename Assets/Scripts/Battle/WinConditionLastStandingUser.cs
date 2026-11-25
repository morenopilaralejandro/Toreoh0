using Aremoreno.Enums.Character;

public class WinConditionLastStandingUser : WinCondition
{
    /*
    private int countCharacters;
    private int countCharactersUserSide;


    there can be up two characters alive for each team
    some teams can have 0 characters

    example
        north 1 alive
        south 2 alive
        east 0  alive

    other side == 0
    user side = 0
    double condition to end game

    public override bool CheckCondition() 
    {
        countCharacters = 0;

        foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
            foreach(CharacterEntityBattle entity in team.TeamComponentCharacter.ListCharacterPointEntity) 
                if (entity.Character.CharacterComponentStats.StatsBattle.Get(Stat.Hp) > 0) // alive
                {
                    countCharacters++;
                    if (entity.Character.CharacterComponentSide.IsSameTeam(battle.BattleComponentTeam.BattleSideUser))
                        countCharactersUserSide++;
                    else 
                        countCharactersOtherSide++;
                }

        return countCharacters <= 1;
    }
    */

    public override bool CheckCondition() 
    {
        return false;
    }

}
