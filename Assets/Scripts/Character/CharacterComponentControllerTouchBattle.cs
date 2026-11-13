using UnityEngine;

public class CharacterComponentControllerTouchBattle : CharacterComponentControllerTouch
{
    [SerializeField] private CharacterEntityBattle entity;
    public bool IsControlled;
    private float rangeMelee = 3f;
    private float rangeMeleeSqr;

    private Move moveTestRange;
    private Move moveTestMelee;

    public void Initialize()
    {
        rangeMeleeSqr = rangeMelee * rangeMelee;
        moveTestRange = MoveFactory.CreateById("move-00000-test_line_uniform");
        moveTestMelee = MoveFactory.CreateById("move-00000-test_melee_slash");
        // if (! is controlled) this.SetActive(false)
    }

    public void SetIsControlled(bool isControlled) => IsControlled = isControlled;

    protected override bool CanMove() => entity.CanMove;
    protected override bool CanAct() => entity.CanAct;

    //protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedRotation() => entity.CharacterComponentModel.SpeedRotation;
    protected override float GetAcceleration() => entity.CharacterComponentRigidbody.Acceleration;

    protected override void ExecuteActionTap()
    {
        if (!entity.CharacterComponentTarget.HasTarget) return;
        entity.CharacterComponentModel.RotateInstant(entity.CharacterComponentTarget.GetDirectionToTarget());
        if ((entity.CharacterComponentTarget.TargetEntity.transform.position - entity.transform.position).sqrMagnitude < rangeMeleeSqr)
        {
            entity.CharacterComponentStateLock.StartStateLock(moveTestMelee.MoveComponentFrame.FrameRecovery);
            BattleManager.Instance.Battle.BattleComponentBullet.AddBullet(entity, moveTestMelee);
        }
        else 
        {
            entity.CharacterComponentStateLock.StartStateLock(moveTestRange.MoveComponentFrame.FrameRecovery);
            BattleManager.Instance.Battle.BattleComponentBullet.AddBullet(entity, moveTestRange);
        }
    }

    protected override void ExecuteActionSwipeUp()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeUp");
    }

    protected override void ExecuteActionSwipeDown()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeDown");
    }

    protected override void ExecuteActionSwipeLeft()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeLeft");
    }

    protected override void ExecuteActionSwipeRight()
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionSwipeRight");
    }

}
