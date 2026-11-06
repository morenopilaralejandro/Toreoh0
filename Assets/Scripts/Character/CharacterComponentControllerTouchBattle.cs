public class CharacterComponentControllerTouchBattle : CharacterComponentControllerTouch
{
    private CharacterEntityBattle entity;

    public void Initialize(CharacterEntityBattle entity)
    {
        this.entity = entity;
        // if (! is controlled) this.SetActive(false)
    }

    protected override bool CanMove() => true;
    protected override bool CanAct() => true;

    //protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedRotation() => entity.CharacterComponentModel.SpeedRotation;
    protected override float GetAcceleration() => entity.CharacterComponentRigidbody.Acceleration;

    protected override void ExecuteActionTap() 
    {
        CustomLog.Error($"[CharacterControllerComponentTouchBattle] ExecuteActionTap");
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
