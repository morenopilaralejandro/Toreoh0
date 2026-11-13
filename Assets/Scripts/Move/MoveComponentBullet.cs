public class MoveComponentBullet
{
    public BulletPattern BulletPattern;

    public MoveComponentBullet(MoveData data) 
    {
        BulletPattern = BulletPatternFactory.CreateById(data.BulletPatternId);
    }
}
