using UnityEngine;

public class Field 
{
    public FieldComponentAttributes AttributesComponent;
    public FieldComponentAppearance AppearanceComponent;
    public FieldComponentConfig ConfigComponent;
    public FieldComponentFormation FormationComponent;
    public FieldComponentFormationBarrier FormationBarrierComponent;
    public FieldComponentTilemap TilemapComponent;
    public FieldComponentProtectObstacle ProtectObstacleComponent;
    public FieldComponentBarrier BarrierComponent;

    public Field(FieldData data) { }
    public Field(
        FieldData data, 
        BattleConfig battleConfig, 
        Transform tileMapParent,
        Transform parentProtectObstacle,
        Transform parentBarrier)
    {
        AttributesComponent = new FieldComponentAttributes(data);
        AppearanceComponent = new FieldComponentAppearance(data);
        ConfigComponent = new FieldComponentConfig(battleConfig);
        FormationComponent = new FieldComponentFormation(this);
        FormationBarrierComponent = new FieldComponentFormationBarrier(data, this);
        TilemapComponent = new FieldComponentTilemap(this, tileMapParent);
        ProtectObstacleComponent = new FieldComponentProtectObstacle(data, this, parentProtectObstacle);
        BarrierComponent = new FieldComponentBarrier(this, parentBarrier);
    }

    public void Dispose() 
    {
        TilemapComponent.Clear();
        ProtectObstacleComponent.Clear();
        BarrierComponent.Clear();
    }
}
