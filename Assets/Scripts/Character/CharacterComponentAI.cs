using UnityEngine;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Character;

public class CharacterComponentAI
{
    private CharacterEntityBattle entity;

    private CharacterComponentRigidbody rb;
    private CharacterComponentModel model;

    public CharacterComponentStateMachine<AIState> StateMachineAI;

    public bool IsAiEnabled = false;

    private float timeNow;
    private float timeNextDecision;
    private float timeChargeEnd;
    private float timeChargeDuration = 10f;
    private float speedMovement;
    private float speedRotation;
    // private float acceleration;

    private float decisionDelayMin;
    private float decisionDelayMax;

    private Vector3 destinationPosition;
    private Vector3 destinationDirection;

    // lifecycle
    public CharacterComponentAI(CharacterEntityBattle entity) 
    {
        this.entity = entity;

        StateMachineAI = new CharacterComponentStateMachine<AIState>();
        speedMovement = entity.Character.CharacterComponentSpeed.SpeedMovement;
        speedRotation = entity.CharacterComponentModel.SpeedRotation;
        rb = entity.CharacterComponentRigidbody;
        model = entity.CharacterComponentModel;
        // acceleration = entity.CharacterComponentRigidbody.Acceleration;
        InitializeDecisionDelay();
        SetIsAiEnabled(true);
    }

    public void InitializeDecisionDelay() 
    {
        switch (entity.Character.CharacterComponentAIScalingDifficulty.AIDifficulty) 
        {
            case AIDifficulty.VeryEasy:
                decisionDelayMin = 0.8f;
                decisionDelayMax = 1f;
                break;   
            case AIDifficulty.Easy:
                decisionDelayMin = 0.8f;
                decisionDelayMax = 0.9f;
                break;   
            case AIDifficulty.Normal:
                decisionDelayMin = 0.6f;
                decisionDelayMax = 0.8f;
                break;   
            case AIDifficulty.Hard:
                decisionDelayMin = 0.4f;
                decisionDelayMax = 0.6f;
                break;   
            case AIDifficulty.VeryHard:
                decisionDelayMin = 0.5f;
                decisionDelayMax = 0.6f;
                break;     
            case AIDifficulty.Impossible:
                decisionDelayMin = 0.4f;
                decisionDelayMax = 0.4f;
                break;        
        }
    }

    public void FixedUpdateInternal()
    {
        timeNow = Time.time;
        if (timeNow >= timeNextDecision)
        {
            timeNextDecision = timeNow + Random.Range(decisionDelayMin, decisionDelayMax);
            UpdateAIState();
        }

        ExecuteAIState();
    }

    // state
    public void UpdateAIState()
    {
        if (!entity.CanMove) StateMachineAI.SetState(AIState.Idle);

        if (entity.CharacterComponentCharge.HasPendingCharge) 
        {
            timeChargeEnd = timeNow + timeChargeDuration;
            entity.CharacterComponentCharge.ConsumeCharge();
            entity.CharacterComponentCharge.SetIsCharging(true);
            destinationDirection = entity.CharacterComponentCharge.GetDirectionToLastCharger();
            RotateToTarget();
            StateMachineAI.SetState(AIState.Charge);
            CustomLog.Error($"[CharacterComponentAI] Charge start {entity.Character.CharacterComponentAttributes.CharacterId}");
        }
    }

    public void ExecuteAIState()
    {
        switch (StateMachineAI.State) 
        {
            case AIState.Charge:
                ActCharge();
                break;        
        }
    }

    // logic
    private void ActCharge() 
    {
        if (timeNow < timeChargeEnd) 
        {
            MoveTowards();
        } else 
        {
            entity.CharacterComponentCharge.SetIsCharging(false);
            StateMachineAI.SetState(AIState.Idle);
        }
    }

    // helper
    private void MoveTowards() 
    {
        UpdateMovement(destinationDirection);
    }

    private void SetDestinationFromTarget(Vector3 target)
    {
        destinationDirection = destinationPosition - entity.transform.position;
    }

    private void UpdateMovement(Vector3 destinationDirection)
    {
        if (!entity.CanMove) return;
        rb.AddForce(destinationDirection * speedMovement * entity.CharacterComponentCharge.SpeedMovementChargeMultiplier);
    }

    private void UpdateRotation(Vector3 destinationDirection)
    {
        if (!entity.CanMove) return;
        model.Rotate(destinationDirection, speedRotation);
    }

    private void RotateToTarget() 
    {
        entity.CharacterComponentModel.RotateInstant(entity.CharacterComponentTarget.GetDirectionToTarget());
    }

    // setter
    public void SetIsAiEnabled(bool isEnable) => IsAiEnabled = isEnable;

    // event
    public void Subscribe() 
    {
        BattleEvents.OnIsEnemyAiEnabledChanged += OnIsEnemyAiEnabledChanged;
    }

    public void Unsubscribe() 
    {
        BattleEvents.OnIsEnemyAiEnabledChanged += OnIsEnemyAiEnabledChanged;
    }

    private void OnIsEnemyAiEnabledChanged(bool isEnable)
    {
        if (entity.CharacterComponentControllerTouchBattle.IsControlled) return;
        SetIsAiEnabled(isEnable);
    }

    /*
    public enum AIState
    {
        Idle,
        Bait, // stand still
        Atack, 
        AtackSpecial,
        Turn, // stand still and rotate to targe
        Move // walk towards target
        Charge, // 
        Target // change target
    }

    public enum AIBehaviour
    {
        Normal,
        Enraged,
        Weak,
        Capture
    }

    change the update frecuency based on difficulty

    when weak or capture -> change fatigue manualy tiread and exausted respectively

    when normal
        normal

    when enraged attack faster
    */

}
