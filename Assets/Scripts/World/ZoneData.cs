using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.World;

[CreateAssetMenu(fileName = "ZoneData", menuName = "ScriptableObject/World/ZoneData")]
public class ZoneData : ScriptableObject
{
    [Header("Generic")]
    public string ZoneId;
    public ZoneType ZoneType;
    public AudioClip Bgm;
    public bool HasDisplayName = true;

    [Header("Overworld")]
    public OverworldData OverworldData;

    [Header("Interior")]
    public string SceneAddressInterior;

    [Header("Encounter")]
    public FieldData FieldData;
    public List<EncounterData> Encounters;

    [Header("SpawnPoint")]
    public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();
}
