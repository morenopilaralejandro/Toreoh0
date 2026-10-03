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

    [Header("Overworld")]
    public OverworldData OverworldData;

    [Header("Interior")]
    public string SceneAddressInterior;

    [Header("Encounter")]
    public FieldData FieldData;
    public List<EncounterData> Encounters;
}
