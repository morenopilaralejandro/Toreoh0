using UnityEngine;
using Aremoreno.Enums.Animation;
using Aremoreno.Enums.World;

[System.Serializable]
public class WorldManagerSaveData
{
    public string ZoneId;
    public float CharacterPositionX;
    public float CharacterPositionY;
    public float CharacterPositionZ;
    public CharacterDirection CharacterFacingDirection;
    public int Hour;
}
