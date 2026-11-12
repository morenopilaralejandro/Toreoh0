public class CharacterComponentControllerTouchBattle : CharacterComponentControllerTouch
{
    private CharacterEntityBattle entity;
    public bool IsControlled;

    public void Initialize(CharacterEntityBattle entity)
    {
        this.entity = entity;
        // if (! is controlled) this.SetActive(false)
    }

    public void SetIsControlled(bool isControlled) => IsControlled = isControlled;

    protected override bool CanMove() => true;
    protected override bool CanAct() => true;

    //protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedRotation() => entity.CharacterComponentModel.SpeedRotation;
    protected override float GetAcceleration() => entity.CharacterComponentRigidbody.Acceleration;

    protected override void ExecuteActionTap()
    {
        if (!entity.CharacterComponentTarget.HasTarget) return;
        entity.CharacterComponentModel.RotateInstant(entity.CharacterComponentTarget.GetDirectionToTarget());
        BattleManager.Instance.Battle.BattleComponentBullet.AddBullet(entity);
        // CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionTap");
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
