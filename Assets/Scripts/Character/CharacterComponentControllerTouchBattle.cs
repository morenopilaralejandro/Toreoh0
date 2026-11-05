public class CharacterComponentControllerTouchBattle : CharacterComponentControllerTouch
{
    private CharacterEntityBattle entity;

    public void Initialize(CharacterEntityBattle entity)
    {
        this.entity = entity;
        // if (! is controlled) this.SetActive(false)
    }

    //protected override float GetSpeedMovement() => entity.Character.CharacterComponentSpeed.SpeedMovement;
    protected override float GetSpeedMovement() => 0.5f;
    protected override float GetSpeedRotation() => 0.5f;
    protected override float GetAcceleration() => 10f;

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
