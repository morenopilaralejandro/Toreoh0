using UnityEngine;

public class Battle 
{
    public BattleComponentConfig ConfigComponent;
    public BattleComponentField FieldComponent;

    public Battle(
        BattleConfig battleConfig, 
        Transform tileMapParent,
        Transform protectObstacleParent)
    {
        ConfigComponent = new BattleComponentConfig(battleConfig);
        FieldComponent = new BattleComponentField(this, tileMapParent, protectObstacleParent);
    }

    public void Dispose() 
    {
        FieldComponent.Dispose();
    }
}
