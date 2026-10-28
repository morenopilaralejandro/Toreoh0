using UnityEngine;

public class Field 
{
    public FieldComponentAttributes AttributesComponent;
    public FieldComponentAppearance AppearanceComponent;
    public FieldComponentConfig ConfigComponent;
    public FieldComponentFormation FormationComponent;
    public FieldComponentTilemap TilemapComponent;
    public FieldComponentProtectObstacle ProtectObstacleComponent;

    public Field(FieldData data)
    {

    }

    public Field(
        FieldData data, 
        BattleConfig battleConfig, 
        Transform tileMapParent,
        Transform parentProtectObstacle)
    {
        AttributesComponent = new FieldComponentAttributes(data);
        AppearanceComponent = new FieldComponentAppearance(data);
        ConfigComponent = new FieldComponentConfig(battleConfig);
        FormationComponent = new FieldComponentFormation(this);
        TilemapComponent = new FieldComponentTilemap(this, tileMapParent);
        ProtectObstacleComponent = new FieldComponentProtectObstacle(this, parentProtectObstacle);
    }

    public void Dispose() 
    {
        TilemapComponent.Clear();
        ProtectObstacleComponent.Clear();
    }
}
