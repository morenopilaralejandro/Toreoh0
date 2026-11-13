using System.Collections.Generic;

public class BulletPatternComponentBullet
{
    public List<BulletData> ListBulletData = new ();

    public BulletPatternComponentBullet(BulletPatternData data) 
    {
        foreach (string bulletId in data.ListBulletId)
            ListBulletData.Add(DatabaseManager.Instance.DatabaseRegistry.BulletData.Get(bulletId));
    }
}
