using UnityEngine;
using Aremoreno.Enums.Character;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string CharacterId;

    public Element Element0;
    public Element Element1;

    public int StatHp;
    public int StatMeleeAttack;
    public int StatMeleeDefense;
    public int StatRangeAttack;
    public int StatRangeDefense;
    public int StatSpeed;

    public int MoveLv0;
    public int MoveLv1;
    public int MoveLv2;
    public int MoveLv3;
    public string MoveId0;
    public string MoveId1;
    public string MoveId2;
    public string MoveId3;

    public string WingId;
}
