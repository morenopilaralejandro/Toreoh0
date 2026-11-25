using UnityEngine;

public class Field 
{
    public FieldComponentAttributes AttributesComponent;
    public FieldComponentAppearance AppearanceComponent;
    public FieldComponentConfig ConfigComponent;
    public FieldComponentFormation FieldComponentFormation;
    public FieldComponentFormationBarrier FormationBarrierComponent;
    public FieldComponentTilemap TilemapComponent;
    public FieldComponentProtectObstacle FieldComponentProtectObstacle;
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
        FieldComponentFormation = new FieldComponentFormation(this);
        FormationBarrierComponent = new FieldComponentFormationBarrier(data, this);
        TilemapComponent = new FieldComponentTilemap(this, tileMapParent);
        FieldComponentProtectObstacle = new FieldComponentProtectObstacle(data, this, parentProtectObstacle);
        BarrierComponent = new FieldComponentBarrier(this, parentBarrier);
    }

    public void Dispose() 
    {
        TilemapComponent.Clear();
        FieldComponentProtectObstacle.Clear();
        BarrierComponent.Clear();
    }
}
