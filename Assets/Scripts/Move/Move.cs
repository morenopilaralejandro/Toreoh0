public class Move 
{
    public MoveComponentAttributes MoveComponentAttributes;
    public MoveComponentLocalization MoveComponentLocalization;
    public MoveComponentBullet MoveComponentBullet;
    public MoveComponentPersistence MoveComponentPersistence;
    public MoveComponentFrame MoveComponentFrame;
    public MoveComponentSfx MoveComponentSfx;

    public Move(MoveData data)
    {
        MoveComponentAttributes = new MoveComponentAttributes(data);
        MoveComponentLocalization = new MoveComponentLocalization(data);
        MoveComponentBullet = new MoveComponentBullet(data);
        MoveComponentFrame = new MoveComponentFrame(data);
        MoveComponentPersistence = new MoveComponentPersistence(this);
        MoveComponentSfx = new MoveComponentSfx(data);
    }
}
