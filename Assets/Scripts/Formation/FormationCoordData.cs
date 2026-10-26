using UnityEngine;

[CreateAssetMenu(fileName = "FormationCoordData", menuName = "ScriptableObject/Formation/FormationCoordData")]
public class FormationCoordData : ScriptableObject
{
    public string FormationCoordId;
    public float FormationCoordPositionX;
    public float FormationCoordPositionY;
    public float FormationCoordPositionZ;
}
