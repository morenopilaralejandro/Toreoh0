using UnityEngine;

public class CharacterComponentControllerTouchBattle : CharacterComponentControllerTouch
{
    [SerializeField] private CharacterEntityBattle entity;
    public bool IsControlled;
    private float rangeMeleeSqr;
    private Move move;

    public void Initialize()
    {
        rangeMeleeSqr = entity.Character.CharacterComponentConfig.Config.RangeMelee * entity.Character.CharacterComponentConfig.Config.RangeMelee;
        // if (! is controlled) this.SetActive(false)
    }

    public void SetIsControlled(bool isControlled) => IsControlled = isControlled;

    protected override bool CanMove() => entity.CanMove && !BattleManager.Instance.Battle.BattleComponentPause.IsPausedBattle;
    protected override bool CanAct() => entity.CanAct && !BattleManager.Instance.Battle.BattleComponentPause.IsPausedBattle;

    //protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedRotation() => entity.CharacterComponentModel.SpeedRotation;
    protected override float GetAcceleration() => entity.CharacterComponentRigidbody.Acceleration;

    protected override void ExecuteActionTap()
    {
        if (!entity.CharacterComponentTarget.HasTarget) return;
        entity.CharacterComponentModel.RotateInstant(entity.CharacterComponentTarget.GetDirectionToTarget());

        if ((entity.CharacterComponentTarget.TargetEntity.transform.position - entity.transform.position).sqrMagnitude < rangeMeleeSqr)
            move = entity.Character.CharacterComponentMove.MoveMelee;
        else 
            move = entity.Character.CharacterComponentMove.MoveRange;

        entity.CharacterComponentStateLock.StartStateLock(move.MoveComponentFrame.FrameRecovery);
        BattleManager.Instance.Battle.BattleComponentBullet.AddBullet(entity, move);
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionTap");
    }

    protected override void ExecuteActionSwipeUp()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeUp");
        // if (!CanAct()) return;
        ExecuteActionSwipeDown();
    }

    protected override void ExecuteActionSwipeDown()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeDown");
        if (BattleManager.Instance.Battle.BattleComponentPause.IsPausedBattle) return;
        UIEvents.RaiseMenuBattleCommandOpenRequested();
    }

    protected override void ExecuteActionSwipeLeft()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeLeft");
        // if (!CanAct()) return;
        ExecuteActionSwipeDown();
    }

    protected override void ExecuteActionSwipeRight()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeRight");
        // if (!CanAct()) return;
        ExecuteActionSwipeDown();
    }
}
