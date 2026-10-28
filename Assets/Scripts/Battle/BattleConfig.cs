using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

[CreateAssetMenu(fileName = "BattleConfig", menuName = "ScriptableObject/Battle/BattleConfig")]
public class BattleConfig : ScriptableObject
{
    [Header("Debug")]
    public bool IsInfiniteHpEnable;
    public bool IsDamageBoostEnable;
    public float DamageBoost;
    public bool IsDebugCatchEnable;

    [Header("Field")]
    public int CountBarrier;
    public int CountCapturePortal;
    public int CountProtectObstacle;

    [Header("Coords")]
    public List<FormationCoordData> ListCoordProtectObstacles;
    public List<BarrierSpawnPositionMapping> ListCoordBarrier;
    public List<CharacterSpawnPositionMapping> ListCoordCharacter;

    [Header ("Barrier")]
    public List<BarrierTypeMapping> ListBarrierTypeMapping;

    public Dictionary<BattleSide, CharacterSpawnPositionMapping> DictListCoordCharacterSpawn = new();
    public Dictionary<BarrierType, BarrierTypeMapping> DictBarrierTypeMapping = new();
    
    public void Initialize() 
    {
        foreach (var mapping in ListCoordCharacter)
            DictListCoordCharacterSpawn[mapping.BattleSide] = mapping;

        foreach (var mapping in ListBarrierTypeMapping)
            DictBarrierTypeMapping[mapping.BarrierType] = mapping;
    }
}

/*
protected obstacles
33
3D

55
5B

77
79

---

97
99

B5
BB

D3
DD

spawn positions
south B8
north 58
west  95
east  8B
*/
