using UnityEngine;
using Aremoreno.Enums.Animation;

[System.Serializable]
public class SpawnPoint
{
    public string SpawnPointId;
    public CharacterDirection FacingDirection;
    public Vector3 SpawnPosition;
    public string ZoneId;
}
