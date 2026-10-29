using UnityEngine;

public class Battle 
{
    public BattleComponentConfig ConfigComponent;
    public BattleComponentField FieldComponent;
    public BattleComponentCharacter CharacterComponent;

    public Battle(
        BattleConfig battleConfig, 
        Transform tileMapParent,
        Transform parentProtectObstacle,
        Transform parentBarrier)
    {
        ConfigComponent = new BattleComponentConfig(battleConfig);
        FieldComponent = new BattleComponentField(this, tileMapParent, parentProtectObstacle, parentBarrier);
    }

    public void Dispose() 
    {
        FieldComponent.Dispose();
        CharacterComponent.Dispose();
    }
}
