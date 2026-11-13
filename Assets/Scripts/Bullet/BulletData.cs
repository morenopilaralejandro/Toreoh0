using UnityEngine;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Bullet;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObject/Bullet/BulletData")]
public class BulletData : ScriptableObject
{
    public string BulletId;
    public float DamageBase;
    public BulletMotionType BulletMotionType;
    public float Ttl;
    public float RadiusHit;
    public float RadiusVisual;
    public float SpeedMovement;
    public float AccelerationMovement;
    public float AmplitudeStart;
    public float AmplitudeDelta;
    public float AngularStart;
    public float AngularDelta;
    public float DirectionFactor;
}
