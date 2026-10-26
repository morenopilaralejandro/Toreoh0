using UnityEngine;

[CreateAssetMenu(fileName = "FieldData", menuName = "ScriptableObject/Field/FieldData")]
public class FieldData : ScriptableObject
{
    public string FieldId;
    public string BarrierId;
    public string ProtectObstacleId;
}
