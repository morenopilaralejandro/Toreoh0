using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Log;

[CreateAssetMenu(fileName = "WorldConfig", menuName = "ScriptableObject/World/WorldConfig")]
public class WorldConfig : ScriptableObject
{
    [Header("Character - Collision")]
    public LayerMask CollisionObstacleLayer;
    public float CollisionCastRadius = 0.4f;

    [Header("Character - Interaction")]
    public LayerMask InteractableLayer;
    public float InteractableDetectionInterval = 5f;
    public float IntractionCastRadius = 0.3f;
    public float IntractionRange = 0.75f;

    [Header("Character - Movement")]
    public float WalkSpeed = 2f;
    public float RunSpeed = 4f;

    [Header("Encounter")]
    public int StepBetweenEncountersBaseMin = 10;
    public int StepBetweenEncountersBaseMax = 30;

    [Header("Editor Creation Tool")]
    public string SceneZoneFolder;
    public string PrefixChunk; //scene_chunk_overworldId_coord
    public string PrefixInterior; //scene_interior_zoneId
    public List<string> SceneEmptyObjects;
    /*
        SpawnPoints
        Transitions
        Npcs
        Interactables
    */
}
