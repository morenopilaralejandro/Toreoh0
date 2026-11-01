using UnityEngine;

public class Battle 
{
    public BattleComponentConfig BattleComponentConfig;
    public BattleComponentField BattleComponentField;
    public BattleComponentTeam BattleComponentTeam;
    public BattleComponentCharacter BattleComponentCharacter;

    public Battle(
        BattleConfig battleConfig, 
        Transform tileMapParent,
        Transform parentProtectObstacle,
        Transform parentBarrier,
        Transform parentCharacter)
    {
        BattleComponentConfig = new BattleComponentConfig(battleConfig);
        BattleComponentField = new BattleComponentField(this, tileMapParent, parentProtectObstacle, parentBarrier);
        BattleComponentTeam = new BattleComponentTeam(this);
        BattleComponentCharacter = new BattleComponentCharacter(this, parentCharacter);
    }

    public void Dispose() 
    {
        BattleComponentField.Dispose();
        BattleComponentCharacter.Dispose();
    }
}
