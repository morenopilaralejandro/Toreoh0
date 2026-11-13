using UnityEngine;
using System;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Bullet;
using Aremoreno.Enums.Move;

public class BattleComponentBullet
{
    private Battle battle;
    private List<BulletStruct> listBulletStruct = new ();
    private float sqrMagnitude;
    private bool isColissionCharacter;
    private RenderParams renderParams;
    private MaterialPropertyBlock matProps;
    private Mesh mesh;
    private Material material;
    private Vector3 scaleDefault = new Vector3(1f, 1f, 0f);
    private Vector3 offsetDefault = new Vector3(0f, 0f, -0.5f);
    private Quaternion rotDefault = Quaternion.identity;
    private ColorManager colorManager;
    private LayerMask layerObstacleBullet;

    // lifecycle
    public BattleComponentBullet(Battle battle, BattleConfig battleConfig)
    {
        this.battle = battle;
        this.mesh = battleConfig.MeshBullet;
        this.material = battleConfig.MaterialBullet;
        matProps = new MaterialPropertyBlock();
        colorManager = ColorManager.Instance;
        renderParams = new RenderParams(material);
        layerObstacleBullet = battleConfig.LayerObstacleBullet;
    }

    public void UpdateInternal() 
    {
        // loop backwards to remove bullets
        for(int i = listBulletStruct.Count - 1; i >= 0; i--)
        {
            // get bullet
            BulletStruct bulletStruct = listBulletStruct[i];
            
            // ttl
            bulletStruct.Ttl -= Time.deltaTime;
            if (bulletStruct.Ttl <= 0) 
            {
                listBulletStruct.RemoveAt(i);          
                continue;  
            }

            // collision obstacle
            if (bulletStruct.IsDestroyedOnObstacle &&
                Physics.CheckSphere(bulletStruct.Pos, bulletStruct.RadiusHit, layerObstacleBullet))
            {
                // CustomLog.Trace($"[BattleComponentBullet] Bullet collided with obstacle. Bullet sourceBattleSide: {bulletStruct.SourceBattleSide}.");
                listBulletStruct.RemoveAt(i);
                continue;  
            }

            // collision character
            isColissionCharacter = false;
            foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
            {
                foreach (CharacterEntityBattle entity in team.TeamComponentCharacter.ListCharacterPointEntity)
                {
                    if (entity.Character.CharacterComponentSide.BattleSide == bulletStruct.SourceBattleSide) continue;
                    sqrMagnitude = (bulletStruct.Pos - entity.transform.position).sqrMagnitude;
                    if (sqrMagnitude < entity.Character.CharacterComponentBullet.RadiusHitSqr)
                    {
                        isColissionCharacter = true;
                        // CustomLog.Warning($"[BattleComponentBullet] Bullet collided with character. CharacterId: {entity.Character.CharacterComponentAttributes.CharacterId}. Bullet sourceBattleSide: {bulletStruct.SourceBattleSide}.");
                        // entity takes damage based on bullet damage
                        break;
                    } else if (sqrMagnitude < entity.Character.CharacterComponentBullet.RadiusGraceSqr)
                    {
                        // CustomLog.Trace($"[BattleComponentBullet] Bullet graced with character. CharacterId: {entity.Character.CharacterComponentAttributes.CharacterId}. Bullet sourceBattleSide: {bulletStruct.SourceBattleSide}.");
                        // entity increases super gauge as reward
                    }
                }
                if (isColissionCharacter) break;         
            }

            if (isColissionCharacter)
            {
                listBulletStruct.RemoveAt(i);
                continue;
            }

            // position
            switch (bulletStruct.BulletMotionType) 
            {
                case BulletMotionType.RectilinearUniform:
                    bulletStruct.Pos += bulletStruct.Dir.normalized * bulletStruct.SpeedMovement * Time.deltaTime;
                    break;
                case BulletMotionType.RectilinearAccelerated:
                    bulletStruct.SpeedMovement += bulletStruct.AccelerationMovement * Time.deltaTime;
                    bulletStruct.Pos += bulletStruct.Dir.normalized * bulletStruct.SpeedMovement * Time.deltaTime;
                    break;
                case BulletMotionType.CurveSpiralUniform:
                    bulletStruct.Amplitude += bulletStruct.AmplitudeDelta;
                    bulletStruct.Dir = Quaternion.Euler(0, 0, bulletStruct.AngularDelta) * bulletStruct.Dir;
                    bulletStruct.Pos += bulletStruct.Dir.normalized * bulletStruct.Amplitude * Time.deltaTime;
                    break;
            }

            // draw
            matProps.SetColor("_Color", colorManager.Palettes.BattleSideBullet.Get(bulletStruct.SourceBattleSide));
            renderParams.matProps = matProps;
            Graphics.RenderMesh(renderParams, mesh, 0, Matrix4x4.TRS(bulletStruct.Pos, bulletStruct.Rot, bulletStruct.Scale));

            // set bullet
            listBulletStruct[i] = bulletStruct;
        }
    }

    // helper

    // leftover
    /*


            Ray ray = new Ray(previousPos, direction);
            if (Physics.Raycast(ray, out var hit, distance)) {
                // Bullet hit detected
            }

    private void GetBulletColor()
    {
            matProps.SetColor();
            propertyBlock.SetColor("_BaseColor", lineColor);

            matProps.SetTexture();
            matProps.SetTexture("_BaseMap", texture);

            renderParams.matProps = matProps;
    }
    */

    // spawn
    public void AddBullet(CharacterEntityBattle characterEntityBattle, Move move)
    {
        foreach(BulletData bulletData in move.MoveComponentBullet.BulletPattern.BulletPatternComponentBullet.ListBulletData)
            AddBullet(
                pos : characterEntityBattle.transform.position + offsetDefault,
                dir : Quaternion.Euler(0, 0, bulletData.AngularStart) * characterEntityBattle.CharacterComponentModel.Model.forward * bulletData.DirectionFactor,
                scale : scaleDefault * bulletData.RadiusVisual,
                rot : rotDefault,
                damageBase : bulletData.DamageBase,
                ttl : bulletData.Ttl,
                radiusHit : bulletData.RadiusHit,
                speedMovement : bulletData.SpeedMovement,
                accelerationMovement : bulletData.AccelerationMovement,
                amplitude : bulletData.AmplitudeStart,
                amplitudeDelta : bulletData.AmplitudeDelta,
                angularDelta : bulletData.AngularDelta,
                isDestroyedOnObstacle : move.MoveComponentAttributes.MoveCategory == MoveCategory.Range,
                sourceBattleSide : characterEntityBattle.Character.CharacterComponentSide.BattleSide,
                sourceEntityIndex : characterEntityBattle.Character.CharacterComponentSide.EntityIndex,
                bulletMotionType : bulletData.BulletMotionType
            );
    }

    public void AddBullet(
        Vector3 pos, 
        Vector3 dir, 
        Vector3 scale,
        Quaternion rot,
        float damageBase,
        float ttl,
        float radiusHit,
        float speedMovement, 
        float accelerationMovement, 
        float amplitude,
        float amplitudeDelta,
        float angularDelta,
        bool isDestroyedOnObstacle,
        int sourceEntityIndex
        BattleSide sourceBattleSide,
        BulletMotionType bulletMotionType)
    {
        listBulletStruct.Add(new BulletStruct 
        {
            Pos = pos,
            Dir = dir,
            Scale = scale,
            Rot = rot,
            DamageBase = damageBase,
            Ttl = ttl,
            RadiusHit = radiusHit,
            SpeedMovement = speedMovement,
            AccelerationMovement = accelerationMovement,
            Amplitude = amplitude,
            AmplitudeDelta = amplitudeDelta,
            AngularDelta = angularDelta,
            IsDestroyedOnObstacle = isDestroyedOnObstacle,
            SourceEntityIndex = sourceEntityIndex.
            SourceBattleSide = sourceBattleSide
            BulletMotionType = bulletMotionType

        });
    }

    // remove
    public void RemoveByBulletSource(BattleSide battleSide, int entityIndex)
    {
        for(int i = listBulletStruct.Count - 1; i >= 0; i--)
        {
            BulletStruct bulletStruct = listBulletStruct[i];
            if (bulletStruct.SourceBattleSide == battleSide && 
                bulletStruct.SourceEntityIndex == entityIndex) 
                listBulletStruct.RemoveAt(i);
        }
    }
}
