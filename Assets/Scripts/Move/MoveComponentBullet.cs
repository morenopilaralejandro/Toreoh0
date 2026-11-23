using System.Collections.Generic;

public class MoveComponentBullet
{
    public List<BulletPattern> ListBulletPattern = new ();

    public MoveComponentBullet(MoveData data) 
    {
        foreach(var mapping in data.ListBulletPatternMapping) 
            ListBulletPattern.Add(BulletPatternFactory.CreateByMapping(mapping));
    }
}
