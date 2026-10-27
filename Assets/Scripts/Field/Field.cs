public class Field 
{
    public FieldComponentAttributes AttributesComponent;
    public FieldComponentAppearance AppearanceComponent;
    public FieldComponentConfig ConfigComponent;
    public FieldComponentFormation FormationComponent;

    public Field(FieldData data)
    {

    }

    public Field(FieldData data, BattleConfig battleConfig)
    {
        AttributesComponent = new FieldComponentAttributes(data);
        AppearanceComponent = new FieldComponentAppearance(data);
        FormationComponent = new FieldComponentFormation(this);
        ConfigComponent = new FieldComponentConfig(battleConfig);
    }
}
