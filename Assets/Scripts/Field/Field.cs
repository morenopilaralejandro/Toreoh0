public class Field 
{
    public FieldComponentAttributes AttributesComponent;
    public FieldComponentAppearance AppearanceComponent;

    public Field(FieldData data)
    {
        AttributesComponent = new FieldComponentAttributes(data);
        AppearanceComponent = new FieldComponentAppearance(data);
    }
}
