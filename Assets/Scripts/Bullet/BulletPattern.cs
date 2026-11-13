public class BulletPattern 
{
    public BulletPatternComponentAttributes BulletPatternComponentAttributes;
    public BulletPatternComponentBullet BulletPatternComponentBullet;

    public BulletPattern(BulletPatternData data)
    {
        BulletPatternComponentAttributes = new BulletPatternComponentAttributes(data);
        BulletPatternComponentBullet = new BulletPatternComponentBullet(data);
    }
}
