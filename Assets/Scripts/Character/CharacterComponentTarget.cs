using UnityEngine;
using Aremoreno.Enums.Battle;

public class CharacterComponentTarget
{
    private CharacterEntityBattle characterEntityBattle;
    public BattleSide BattleSide;

    public int IndexTargetTeam;
    public int IndexTargetCharacter;
    public CharacterEntityBattle TargetEntity;

    public void SetIndexTargetTeam(int indexTargetTeam) => IndexTargetTeam = indexTargetTeam;
    public void SetIndexTargetCharacter(int indexTargetCharacter) => IndexTargetCharacter = indexTargetCharacter;
    public void SetTargetEntity(CharacterEntityBattle targetEntity) => TargetEntity = targetEntity;

    public CharacterComponentTarget(CharacterEntityBattle characterEntityBattle) 
    {
        this.characterEntityBattle = characterEntityBattle;
    }

    public Vector3 GetDirectionToTarget() 
    {
        if (!HasTarget) return Vector3.zero;
        return TargetEntity.transform.position - characterEntityBattle.transform.position;
    }

    public bool HasTarget => TargetEntity != null;
}
