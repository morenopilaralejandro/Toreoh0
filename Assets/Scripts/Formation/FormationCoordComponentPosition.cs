using UnityEngine;

public class FormationCoordComponentPosition
{
    public Vector3 FormationCoordPosition;

    public FormationCoordComponentPosition(FormationCoordData data) 
    {
        FormationCoordPosition = new Vector3(data.FormationCoordPositionX, data.FormationCoordPositionY, data.FormationCoordPositionZ);
    }
}
