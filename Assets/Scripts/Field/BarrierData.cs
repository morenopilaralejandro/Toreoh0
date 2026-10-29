using UnityEngine;
using Aremoreno.Enums.Battle;

[CreateAssetMenu(fileName = "BarrierData", menuName = "ScriptableObject/Field/BarrierData")]
public class BarrierData : ScriptableObject
{
    public string BarrierId;
    public BarrierType BarrierType;
    public string SpriteAddress;
    public string SfxAddress;
}
