using UnityEngine;

public class FormationCoordComponentRotation
{
    public Quaternion FormationCoordRotation = Quaternion.identity;

    public FormationCoordComponentRotation(FormationCoordData data) 
    {
        
    }

    public void SetRotationEuler(float rotX, float rotY, float rotZ) 
    {
        FormationCoordRotation = Quaternion.Euler(rotX, rotY, rotZ);
    }
}
