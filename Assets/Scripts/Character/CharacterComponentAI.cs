using UnityEngine;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Character;

public class CharacterComponentAI
{
    private CharacterEntityBattle entity;

    private CharacterComponentRigidbody rb;
    private CharacterComponentModel model;
    private Move move;

    public CharacterComponentStateMachine<AIState> StateMachineAI;
    public bool IsAiEnabled = false;

    private float timeNow;
    private float timeNextDecision;
    private float speedMovement;
    private float speedRotation;
    // private float acceleration;

    private float rangeMeleeSqr;

    private float decisionDelayMin;
    private float decisionDelayMax;

    private float destinationArrivalSqr = 5f * 5f;
    private float destinationArrivalSqrCharge;
    private float destinationRotationAngle = 45f;
    private Vector3 destinationPosition;
    private Vector3 destinationDirection;
    private Vector3 positionLastCharger;

    private int countActionsPeformed;
    private int countActionsPeformedThreshold;

    // lifecycle
    public CharacterComponentAI(CharacterEntityBattle entity) 
    {
        this.entity = entity;

        rangeMeleeSqr = entity.Character.CharacterComponentConfig.Config.RangeMelee * entity.Character.CharacterComponentConfig.Config.RangeMelee;
        StateMachineAI = new CharacterComponentStateMachine<AIState>();
        speedMovement = entity.Character.CharacterComponentSpeed.SpeedMovement;
        speedRotation = entity.CharacterComponentModel.SpeedRotation;
        rb = entity.CharacterComponentRigidbody;
        model = entity.CharacterComponentModel;
        // acceleration = entity.CharacterComponentRigidbody.Acceleration;
        destinationArrivalSqrCharge = entity.Character.CharacterComponentBullet.RadiusHitSqr;
        InitializeDecisionDelay();
        InitializeByBehaviour(AIBehaviour.Normal);
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

    private void InitializeByBehaviour(AIBehaviour behaviour) 
    {
        switch (behaviour) 
        {
            case AIBehaviour.Normal:
                countActionsPeformedThreshold = 2;
                break;
            case AIBehaviour.Rage:
                countActionsPeformedThreshold = 0;
                break;
            case AIBehaviour.Weak:
                countActionsPeformedThreshold = 99;
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

        //CustomLog.Trace($"[CharacterComponentAI] State: {StateMachineAI.State}");
        if (!entity.CanMove) return;
        if (!entity.CharacterComponentTarget.HasTarget) return;
        ExecuteAIState();
    }

    // state
    public void UpdateAIState()
    {
        if (!entity.CanMove || !entity.CharacterComponentTarget.HasTarget) 
            StateMachineAI.SetState(AIState.Idle);
        else if (entity.CharacterComponentCharge.HasPendingCharge || entity.CharacterComponentCharge.IsCharging)
            StateMachineAI.SetState(AIState.Charge);
        else if (!IsFacingTarget())
            StateMachineAI.SetState(AIState.Turn);
        else if (!IsCloseToTarget())
            StateMachineAI.SetState(AIState.Move);
        else
            StateMachineAI.SetState(AIState.Attack);
    }

    public void ExecuteAIState()
    {
        switch (StateMachineAI.State) 
        {
            case AIState.Attack:
                ActAttack();
                break;   
            case AIState.Turn:
                ActRotate();
                break;   
            case AIState.Move:
                ActMove();
                break;   
            case AIState.Charge:
                ActCharge();
                break;        
        }
    }

    // logic
    private void ActCharge() 
    {
        if (entity.CharacterComponentCharge.HasPendingCharge) 
        {
            // start charge
            entity.CharacterComponentCharge.ConsumeCharge();
            RotateToTargetInstant(entity.CharacterComponentCharge.GetDirectionToLastCharger());
            positionLastCharger = entity.CharacterComponentCharge.LastChargerEntity.transform.position;
            entity.CharacterComponentCharge.SetIsCharging(true);
        }
        else if (entity.CharacterComponentCharge.IsCharging)
        {
            // execute charge
            destinationDirection = positionLastCharger - entity.transform.position;
            if (!HasArrivedCharge())
                MoveTowards();
            else 
                entity.CharacterComponentCharge.SetIsCharging(false);
        }
    }

    private void ActRotate() 
    {
        destinationDirection = entity.CharacterComponentTarget.GetDirectionToTarget();
        RotateTowards();
    }

    private void ActMove()
    {
        // RotateToTargetInstant(entity.CharacterComponentCharge.GetDirectionToLastCharger());
        destinationDirection = entity.CharacterComponentTarget.GetDirectionToTarget();
        MoveTowards();
    }

    private void ActAttack()
    {
        if (entity.CharacterComponentAIBehaviour.AIBehaviour == AIBehaviour.Capture) return;
        RotateToTargetInstant(entity.CharacterComponentTarget.GetDirectionToTarget());

        if (countActionsPeformed > countActionsPeformedThreshold)
            PerformMoveSpecial();
        else
            PerformMoveNormal();
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

    private void RotateTowards() 
    {
        UpdateRotation(destinationDirection);
    }

    private void UpdateRotation(Vector3 destinationDirection)
    {
        if (!entity.CanMove) return;
        model.Rotate(destinationDirection, speedRotation);
    }

    private void RotateToTargetInstant(Vector3 direction) 
    {
        entity.CharacterComponentModel.RotateInstant(direction);
    }

    private bool HasArrived()
    {
        return destinationDirection.sqrMagnitude < destinationArrivalSqr;
    }

    private bool HasArrivedCharge()
    {
        return destinationDirection.sqrMagnitude < destinationArrivalSqrCharge;
    }

    private bool IsCloseToTarget() 
    {
        return entity.CharacterComponentTarget.GetDirectionToTarget().sqrMagnitude < destinationArrivalSqr;
    }

    private bool HasRotated()
    {
        return Vector3.Angle(destinationDirection, entity.CharacterComponentModel.Model.forward) < destinationRotationAngle;
    }

    private bool IsFacingTarget()
    {
        return Vector3.Angle(entity.CharacterComponentTarget.GetDirectionToTarget(), entity.CharacterComponentModel.Model.forward) < destinationRotationAngle;
    }

    private void PerformMoveNormal()
    {
        countActionsPeformed++;
        if ((entity.CharacterComponentTarget.TargetEntity.transform.position - entity.transform.position).sqrMagnitude < rangeMeleeSqr)
            move = entity.Character.CharacterComponentMove.MoveMelee;
        else 
            move = entity.Character.CharacterComponentMove.MoveRange;

        PerformMove(move);
    }

    private void PerformMoveSpecial()
    {
        countActionsPeformed = 0;
        if ((entity.CharacterComponentTarget.TargetEntity.transform.position - entity.transform.position).sqrMagnitude < rangeMeleeSqr)
            move = entity.CharacterComponentAIDecisionMove.GetSpecialMoveMeleeSecuencial();
        else 
            move = entity.CharacterComponentAIDecisionMove.GetSpecialMoveRangeSecuencial();

        PerformMove(move);
    }

    private void PerformMove(Move move)
    {
        entity.CharacterComponentStateLock.StartStateLock(move.MoveComponentFrame.FrameRecovery);
        BattleManager.Instance.Battle.BattleComponentBullet.AddBullet(entity, move);
    }

    // setter
    public void SetIsAiEnabled(bool isEnable) => IsAiEnabled = isEnable;

    // event
    public void Subscribe() 
    {
        BattleEvents.OnIsEnemyAiEnabledChanged += OnIsEnemyAiEnabledChanged;
        entity.CharacterComponentAIBehaviour.OnAIBehaviourChanged += OnAIBehaviourChanged;
    }

    public void Unsubscribe() 
    {
        BattleEvents.OnIsEnemyAiEnabledChanged -= OnIsEnemyAiEnabledChanged;
        entity.CharacterComponentAIBehaviour.OnAIBehaviourChanged -= OnAIBehaviourChanged;
    }

    private void OnIsEnemyAiEnabledChanged(bool isEnable)
    {
        if (entity.CharacterComponentControllerTouchBattle.IsControlled) return;
        SetIsAiEnabled(isEnable);
    }

    private void OnAIBehaviourChanged(AIBehaviour behaviour) 
    {
        InitializeByBehaviour(behaviour);
    }
}
