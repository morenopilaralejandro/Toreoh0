using UnityEngine;
using Aremoreno.Enums.World;

[CreateAssetMenu(fileName = "ChestData", menuName = "ScriptableObject/World/ChestData")]
public class ChestData : ScriptableObject
{
    public string ChestId;
    public string ItemId;
    public ChestState DefaultState;
}
