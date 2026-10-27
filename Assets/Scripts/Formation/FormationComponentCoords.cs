using System.Collections.Generic;

public class FormationComponentCoords 
{
    public List<FormationCoord> ListFormationCoord = new ();

    public FormationComponentCoords() 
    {

    }

    public void Add(FormationCoordData data) 
    {
        ListFormationCoord.Add(FormationCoordFactory.Create(data));
    }
}
