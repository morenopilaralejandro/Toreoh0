public class Formation
{
    public FormationComponentCoords CoordsComponent;

    public Formation() 
    {
        CoordsComponent = new FormationComponentCoords();
    }

    public Formation(FormationData data)
    {
        //AttributesComponent = new FieldComponentAttributes(data);
    }

    /*
    public Formation(string hash)
    {
        AttributesComponent = new FieldComponentAttributes(data);
    }
    */
}
