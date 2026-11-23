public class BulletPattern 
{
    public BulletPatternComponentAttributes BulletPatternComponentAttributes;
    public BulletPatternComponentBullet BulletPatternComponentBullet;
    public BulletPatternComponentDamage BulletPatternComponentDamage;

    public BulletPattern(BulletPatternData data)
    {
        BulletPatternComponentAttributes = new BulletPatternComponentAttributes(data);
        BulletPatternComponentBullet = new BulletPatternComponentBullet(data);
    }

    public BulletPattern(BulletPatternData data, int damageBase)
    {
        BulletPatternComponentAttributes = new BulletPatternComponentAttributes(data);
        BulletPatternComponentBullet = new BulletPatternComponentBullet(data);
        BulletPatternComponentDamage = new BulletPatternComponentDamage(damageBase);
    }
}
