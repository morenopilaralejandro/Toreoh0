using UnityEngine;
using Aremoreno.Enums.Character;

public class CharacterComponentColliderCharge : MonoBehaviour
{
    public CharacterEntityBattle CharacterEntityBattle;
    [SerializeField] private BattleConfig battleConfig;

    private void OnCollisionEnter(Collision other) 
    {
        HandleCollision(other);
    }

    private void OnCollisionStay(Collision other) 
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collision other) 
    {
        if (!CharacterEntityBattle.CharacterComponentCharge.IsCharging) return;
        string tag = other.gameObject.tag;
        if (tag == battleConfig.TagCharacter)
            HandleCollisionCharacter(other);
        else if (tag == battleConfig.TagBarrier)
            HandleCollisionBarrier(other);
        else if (tag == battleConfig.TagProtectObstacle)
            HandleCollisionProtectObstacle(other);
    }

    private void HandleCollisionCharacter(Collision other) 
    {
        CharacterEntityBattle character = other.gameObject.GetComponent<CharacterComponentColliderCharge>().CharacterEntityBattle;
        // if (CharacterEntityBattle.Character.CharacterComponentSide.IsSameTeam(character.Character)) return;
        if (character.CharacterComponentAIBehaviour.AIBehaviour == AIBehaviour.Weak) return;
        character.Character.CharacterComponentStats.ModifyStatsBattleWithClamp(Stat.Hp, -(character.Character.CharacterComponentStats.StatsBattle.Get(Stat.Hp) + 10));
        UIEvents.RaiseCharacterHpDecreased(character);
    }

    private void HandleCollisionBarrier(Collision other)
    {
        other.gameObject.GetComponent<BarrierComponentColliderBreak>().Break();
        CharacterEntityBattle.Character.CharacterComponentStatusEffectVolatile.ApplyStatus(StatusEffectVolatile.Stunned);
    }

    private void HandleCollisionProtectObstacle(Collision other)
    {
        other.gameObject.GetComponent<ProtectObstacleComponentColliderBreak>().Break();
        CharacterEntityBattle.Character.CharacterComponentStatusEffectVolatile.ApplyStatus(StatusEffectVolatile.Stunned);
    }
}

/*
        CustomLog.Error(
            $"[CharacterComponentColliderCharge] [OnCollisionEnter] " +
            $"--- This data --- " +
            $"CharacterId: {CharacterEntityBattle.Character.CharacterComponentAttributes.CharacterId}, " +
            $"IsCharging: {CharacterEntityBattle.CharacterComponentCharge.IsCharging}. " +
            $"--- Other data --- " +
            $"name: {other.gameObject.name}, " +
            $"tag: {other.gameObject.tag}, " +
            $"is equal TagCharacter: {other.gameObject.tag == battleConfig.TagCharacter}, " +
            $"is equal TagBarrier: {other.gameObject.tag == battleConfig.TagBarrier}, " +
            $"is equal TagProtectObstacle: {other.gameObject.tag == battleConfig.TagProtectObstacle}, "
        );
*/
