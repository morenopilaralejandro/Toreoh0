using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

[CreateAssetMenu(fileName = "BattleConfig", menuName = "ScriptableObject/Battle/BattleConfig")]
public class BattleConfig : ScriptableObject
{
    [Header("Debug")]
    public bool IsEnemyAIEnable;
    public bool IsInfiniteHpEnable;
    public bool IsDamageBoostEnable;
    public float DamageBoost;
    public bool IsDebugCaptureEnable;

    [Header("Tag")]
    public string TagCharacter;
    public string TagBarrier;
    public string TagProtectObstacle;
    public string TagCapturePortal;

    [Header("General")]
    public List<BattlePhaseMapping> ListBattlePhaseMapping;

    [Header("Field")]
    public int CountBarrier;
    public int CountCapturePortal;
    public int CountProtectObstacle;

    [Header("Coords")]
    public List<FormationCoordData> ListCoordProtectObstacles;
    public List<CharacterSpawnPositionMapping> ListCoordCharacter;

    [Header("Bullet")]
    public Mesh MeshBullet;
    public Material MaterialBullet;
    public LayerMask LayerObstacleBullet;

    public Dictionary<BattleSide, CharacterSpawnPositionMapping> DictCoordCharacterSpawn = new();
    public Dictionary<BattlePhase, BattlePhaseMapping> DictBattlePhaseMapping = new();

    public void Initialize() 
    {
        foreach (var mapping in ListCoordCharacter)
            DictCoordCharacterSpawn[mapping.BattleSide] = mapping;
        foreach (var mapping in ListBattlePhaseMapping)
            DictBattlePhaseMapping[mapping.BattlePhase] = mapping;
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
