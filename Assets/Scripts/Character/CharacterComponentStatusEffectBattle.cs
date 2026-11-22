using UnityEngine;
using System.Collections;
using Aremoreno.Enums.Character;

public class CharacterComponentStatusEffectBattle : MonoBehaviour
{
    [SerializeField] private CharacterEntityBattle entity;
    private Coroutine coroutineStun;

    // stun
    private void StartStun()
    {
        StopStun();
        StartCoroutine(ExecuteStun(entity.Character.CharacterComponentConfig.Config.StatusDurationStun));
    }

    private void StopStun()
    {
        if (coroutineStun == null) return;
        StopCoroutine(coroutineStun);
        coroutineStun = null;
    }

    private IEnumerator ExecuteStun(float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration) 
        {
            // if (frozen) return;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        entity.Character.CharacterComponentStatusEffectVolatile.ClearStun();
    }

    // event
    public void Subscribe()
    {
        entity.Character.CharacterComponentStatusEffectVolatile.OnStatusApplied += OnStatusVolatileApplied;
        entity.Character.CharacterComponentStatusEffectVolatile.OnStatusCleared += OnStatusVolatileCleared;
        entity.Character.CharacterComponentStatusEffectPermanent.OnStatusApplied += OnStatusPermanentApplied;
        entity.Character.CharacterComponentStatusEffectPermanent.OnStatusCleared += OnStatusPermanentCleared;
    }

    public void Unsubscribe()
    {
        entity.Character.CharacterComponentStatusEffectVolatile.OnStatusApplied -= OnStatusVolatileApplied;
        entity.Character.CharacterComponentStatusEffectVolatile.OnStatusCleared -= OnStatusVolatileCleared;
        entity.Character.CharacterComponentStatusEffectPermanent.OnStatusApplied -= OnStatusPermanentApplied;
        entity.Character.CharacterComponentStatusEffectPermanent.OnStatusCleared -= OnStatusPermanentCleared;
    }

    private void OnStatusVolatileApplied(StatusEffectVolatile status) 
    {
        CustomLog.Error(
            $"[CharacterComponentStatusEffectBattle] " +
            $"{entity.Character.CharacterComponentAttributes.CharacterId} " +
            $"applied volatile status " +
            $"{status}."
        );

        switch(status)
        {
            case StatusEffectVolatile.Stunned:
                entity.CharacterComponentCharge.SetIsCharging(false);
                StartStun();
                break;
        }
    }

    private void OnStatusVolatileCleared(StatusEffectVolatile status) 
    {
        CustomLog.Error(
            $"[CharacterComponentStatusEffectBattle] " +
            $"{entity.Character.CharacterComponentAttributes.CharacterId} " +
            $"cleared status " +
            $"{status}."
        );

        switch(status)
        {
            case StatusEffectVolatile.Stunned:
                break;
        } 
    }

    private void OnStatusPermanentApplied(StatusEffectPermanent status) 
    {
        CustomLog.Error(
            $"[CharacterComponentStatusEffectBattle] " +
            $"{entity.Character.CharacterComponentAttributes.CharacterId} " +
            $"applied permanent status " +
            $"{status}."
        );

        switch(status)
        {
            case StatusEffectPermanent.Fainted:
                break;
        }
    }

    private void OnStatusPermanentCleared(StatusEffectPermanent status) 
    {
        CustomLog.Error(
            $"[CharacterComponentStatusEffectBattle] " +
            $"{entity.Character.CharacterComponentAttributes.CharacterId} " +
            $"cleared permanent status " +
            $"{status}."
        );

        switch(status)
        {
            case StatusEffectPermanent.Fainted:
                break;
        }
    }
}

/*

*/
