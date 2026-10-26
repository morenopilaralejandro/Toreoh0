using UnityEngine;
using Aremoreno.Enums.Battle;

[CreateAssetMenu(fileName = "BattleConfig", menuName = "ScriptableObject/Battle/BattleConfig")]
public class BattleConfig : ScriptableObject
{
    [Header("Debug")]
    public bool IsInfiniteHpEnable;
    public bool IsDamageBoostEnable;
    public float DamageBoost;
    public bool IsDebugCatchEnable;
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
