using Aremoreno.Enums.Character;

public class WinConditionLastStanding : WinCondition 
{
    private int countCharacters;

    public override bool CheckCondition() 
    {
        countCharacters = 0;

        foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
            foreach(CharacterEntityBattle entity in team.TeamComponentCharacter.ListCharacterPointEntity) 
                if (entity.Character.CharacterComponentStats.StatsBattle.Get(Stat.Hp) > 0)
                    countCharacters++;

        return countCharacters <= 1;
    }
}

/*
    public override void Initialize(Battle battle)
    {
        base.Initialize(battle);
    }

        totalCharacters = 0;
        foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
            foreach(CharacterEntityBattle entity in team.TeamComponentCharacter.ListCharacterPointEntity)
                totalCharacters++;
*/
