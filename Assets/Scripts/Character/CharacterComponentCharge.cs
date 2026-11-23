using UnityEngine;
using Aremoreno.Enums.Character;
using Aremoreno.Enums.Battle;

public class CharacterComponentCharge
{
    private CharacterEntityBattle entity;

    public CharacterEntityBattle LastChargerEntity;
    public bool HasPendingCharge;
    public bool IsCharging;

    private float countCharge;
    private float deltaCharge = 1f;
    private float threshold = 300f;
    private float thresholdMultiplier = 1.1f;

    public float SpeedMovementChargeMultiplier;
    private float speedMovementChargeMultiplierDefault = 1f;
    private float speedMovementChargeMultiplierCharging = 25f;

    public CharacterComponentCharge(CharacterEntityBattle entity) 
    {
        this.entity = entity;
        SpeedMovementChargeMultiplier = speedMovementChargeMultiplierDefault;
    }

    public void FixedUpdateInternal()
    {
        if(!entity.CharacterComponentControllerTouchBattle.IsControlled) return;
        // if(!entity.CanMove) return;
        if(entity.CharacterComponentControllerTouchBattle.IsMoving()) return;
        if(!entity.CharacterComponentTarget.HasTarget) return;
        entity.CharacterComponentTarget.TargetEntity.CharacterComponentCharge.IncreaseCharge();
        entity.CharacterComponentTarget.TargetEntity.CharacterComponentCharge.SetLastChargerEntity(entity);
    }

    public void IncreaseCharge()
    {
        if (HasPendingCharge || IsCharging) return;
        countCharge += deltaCharge;
        if (countCharge >= threshold) 
        {
            HasPendingCharge = true;
            threshold *= thresholdMultiplier;
        }
    }

    public void ConsumeCharge()
    {
        countCharge = 0;
        HasPendingCharge = false;
    }

    public void SetIsCharging(bool boolValue)
    {
        IsCharging = boolValue;
        if (IsCharging)
            SpeedMovementChargeMultiplier = speedMovementChargeMultiplierCharging;
        else
            SpeedMovementChargeMultiplier = speedMovementChargeMultiplierDefault;
    }

    public void SetLastChargerEntity(CharacterEntityBattle entity)
    {
        LastChargerEntity = entity;
    }

    public Vector3 GetDirectionToLastCharger() 
    {
        if (LastChargerEntity == null) return Vector3.zero;
        return LastChargerEntity.transform.position - entity.transform.position;
    }
}
