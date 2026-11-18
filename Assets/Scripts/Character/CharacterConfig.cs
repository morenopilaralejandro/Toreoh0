using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Character;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScriptableObject/Character/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    //[Header("Debug")]
    //public bool IsDebugStorage;

    [Header("Level")]
    public int LevelMin;
    public int LevelMax;
    public int ScalingBase;
    public int ScalingMultiplier;
    public int ScalingExponent;
    public ScalingStrategy ScalingStrategy;

    [Header("Stats")]
    public List<StatsScalingMapping> ListStatsScalingMapping;

    [Header("Fatigue")]
    public List<FatigueMapping> ListFatigueMapping;

    [Header("AI Scaling")]
    public List<ScalingDifficultyMapping> ListScalingDifficultyMapping;

    public Dictionary<FatigueState, FatigueMapping> DictFatigueMapping = new();

    public void Initialize() 
    {
        foreach (var mapping in ListFatigueMapping)
            DictFatigueMapping[mapping.FatigueState] = mapping;
    }

}
