using UnityEngine;

public class Battle 
{
    public BattleComponentConfig BattleComponentConfig;
    public BattleComponentAttributes BattleComponentAttributes;
    public BattleComponentField BattleComponentField;
    public BattleComponentTeam BattleComponentTeam;
    public BattleComponentCharacter BattleComponentCharacter;
    public BattleComponentPersistence BattleComponentPersistence;
    public BattleComponentEnd BattleComponentEnd;

    public Battle(
        BattleConfig battleConfig, 
        Transform tileMapParent,
        Transform parentProtectObstacle,
        Transform parentBarrier,
        Transform parentCharacter)
    {
        BattleComponentConfig = new BattleComponentConfig(battleConfig);
        BattleComponentAttributes = new BattleComponentAttributes();
        BattleComponentField = new BattleComponentField(this, tileMapParent, parentProtectObstacle, parentBarrier);
        BattleComponentTeam = new BattleComponentTeam(this);
        BattleComponentCharacter = new BattleComponentCharacter(this, parentCharacter);
        BattleComponentPersistence = new BattleComponentPersistence(this);
        BattleComponentEnd = new BattleComponentEnd(this);
    }

    public void Dispose() 
    {
        BattleComponentField.Dispose();
        BattleComponentCharacter.Dispose();
    }
}
