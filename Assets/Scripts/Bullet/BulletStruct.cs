using UnityEngine;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Bullet;

[System.Serializable]
public struct BulletStruct
{
    public Vector3 Pos;
    public Vector3 Dir;
    public Vector3 Scale;
    public Quaternion Rot;
    public float DamageBase;
    public float Ttl;
    public float RadiusHit;
    public float SpeedMovement;
    public float AccelerationMovement;
    public float Amplitude;
    public float AmplitudeDelta;
    public float AngularDelta;
    public bool IsDestroyedOnObstacle;
    public int SourceEntityIndex
    public BattleSide SourceBattleSide;
    public BulletMotionType BulletMotionType;
}
