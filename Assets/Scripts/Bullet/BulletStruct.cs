using UnityEngine;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Bullet;

[System.Serializable]
public struct BulletStruct
{
    public Vector3 Pos;
    public Vector3 Dir;
    public Vector3 Scale;
    public Vector3 Center;
    public Quaternion Rot;
    public float SpeedMovement;
    public float Ttl;
    public float RadiusHit;
    public float Amplitude;
    public BulletMotionType BulletMotionType;
    public BattleSide SourceBattleSide;
}
