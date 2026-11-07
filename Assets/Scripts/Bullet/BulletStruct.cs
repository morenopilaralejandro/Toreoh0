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
    public float SpeedMovement;
    public float Ttl;
    public float Radius;
    public float RadiusVisual;
    public BulletState BulletState;
    public BattleSide SourceSide;
}
