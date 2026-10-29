using UnityEngine;

[CreateAssetMenu(fileName = "FormationBarrierData", menuName = "ScriptableObject/Formation/FormationBarrierData")]
public class FormationBarrierData : ScriptableObject
{
    public string FormationBarrierId;

    public string BarrierId0;
    public string CoordId0;
    public float RotationZ0;

    public string BarrierId1;
    public string CoordId1;
    public float RotationZ1;

    public string BarrierId2;
    public string CoordId2;
    public float RotationZ2;

    public string BarrierId3;
    public string CoordId3;
    public float RotationZ3;
}
