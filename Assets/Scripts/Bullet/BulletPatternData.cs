using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Bullet;

[CreateAssetMenu(fileName = "BulletPatternData", menuName = "ScriptableObject/Bullet/BulletPatternData")]
public class BulletPatternData : ScriptableObject
{
    public string BulletPatternId;
    public List<string> ListBulletId;
}
