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
    public List<CharacterSpawnPositionMapping> ListCoordCharacter;

    public Dictionary<BattleSide, CharacterSpawnPositionMapping> DictListCoordCharacterSpawn = new();
    
    public void Initialize() 
    {
        foreach (var mapping in ListCoordCharacter)
            DictListCoordCharacterSpawn[mapping.BattleSide] = mapping;
    }
}

/*
protected obstacles
22
2D

44
4B

66
69

---

96
99

B4
BB

D2
DD


spawn positions
south B8
north 47
west  84
east  7B

barriers
south D8
north 28
west  72
east  7D

*/
