using UnityEngine;
using System;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Bullet;

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
            if (Physics.CheckSphere(bulletStruct.Pos, bulletStruct.RadiusHit, layerObstacleBullet))
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
                    bulletStruct.Amplitude += 0.1f;
                    bulletStruct.Dir = Quaternion.Euler(0, 0, bulletStruct.SpeedMovement) * bulletStruct.Dir;
                    bulletStruct.Pos += bulletStruct.Dir.normalized * bulletStruct.Amplitude * Time.deltaTime;
                    break;



                /*

                // negative speed changes the rotation direction
                case BulletMotionType.RectilinearUniform:
                    bulletStruct.Amplitude += Time.deltaTime;
                    bulletStruct.Pos.x = (Mathf.Cos(bulletStruct.SpeedMovement * Time.time) * bulletStruct.Amplitude) + bulletStruct.Center.x;
                    bulletStruct.Pos.y = (Mathf.Sin(bulletStruct.SpeedMovement * Time.time) * bulletStruct.Amplitude) + bulletStruct.Center.y;
                    break;


                case BulletMotionType.RectilinearUniform:
                    bulletStruct.Dir = Quaternion.Euler(0, 0, 2 *) * bulletStruct.Dir;
                    bulletStruct.Pos += bulletStruct.Dir.normalized * bulletStruct.SpeedMovement * Time.deltaTime;
                    break;


                case BulletMotionType.RectilinearUniform:
                    bulletStruct.Pos += bulletStruct.Dir.normalized * bulletStruct.SpeedMovement * Time.deltaTime;
                    break;

                */
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
    public void AddBullet(CharacterEntityBattle characterEntityBattle)
    {
        // patter build a dict at start up from the database
        // get the pattern from the move
        // add one for each bullet in the pattern

    
        // spin
        //for arms change amplitude and speed
        // reverse forward for elix effect
        // revese speed of direction
        AddBullet(
            pos : characterEntityBattle.transform.position + offsetDefault,
            dir : Quaternion.Euler(0, 0, 0) * characterEntityBattle.CharacterComponentModel.Model.forward, // bullet direction offset z
            scale : scaleDefault * 0.3f, // bullet visual radius
            rot : rotDefault,
            center : characterEntityBattle.transform.position + offsetDefault,
            speedMovement : 1.1f,
            ttl : 10f,
            radiusHit : 0.2f, // bullet hit radius
            ampitude : 1f,
            bulletMotionType : BulletMotionType.RectilinearUniform,
            sourceBattleSide : characterEntityBattle.Character.CharacterComponentSide.BattleSide
        );
        AddBullet(
            pos : characterEntityBattle.transform.position + offsetDefault,
            dir : Quaternion.Euler(0, 0, 0) * characterEntityBattle.CharacterComponentModel.Model.forward, // bullet direction offset z
            scale : scaleDefault * 0.3f, // bullet visual radius
            rot : rotDefault,
            center : characterEntityBattle.transform.position + offsetDefault,
            speedMovement : 1.1f,
            ttl : 10f,
            radiusHit : 0.2f, // bullet hit radius
            ampitude : 1.5f,
            bulletMotionType : BulletMotionType.RectilinearUniform,
            sourceBattleSide : characterEntityBattle.Character.CharacterComponentSide.BattleSide
        );

        AddBullet(
            pos : characterEntityBattle.transform.position + offsetDefault,
            dir : Quaternion.Euler(0, 0, 0) * -characterEntityBattle.CharacterComponentModel.Model.forward, // bullet direction offset z
            scale : scaleDefault * 0.3f, // bullet visual radius
            rot : rotDefault,
            center : characterEntityBattle.transform.position + offsetDefault,
            speedMovement : 1.5f,
            ttl : 10f,
            radiusHit : 0.2f, // bullet hit radius
            ampitude : 1f,
            bulletMotionType : BulletMotionType.RectilinearUniform,
            sourceBattleSide : characterEntityBattle.Character.CharacterComponentSide.BattleSide
        );
        AddBullet(
            pos : characterEntityBattle.transform.position + offsetDefault,
            dir : Quaternion.Euler(0, 0, 0) * -characterEntityBattle.CharacterComponentModel.Model.forward, // bullet direction offset z
            scale : scaleDefault * 0.3f, // bullet visual radius
            rot : rotDefault,
            center : characterEntityBattle.transform.position + offsetDefault,
            speedMovement : 1.5f,
            ttl : 10f,
            radiusHit : 0.2f, // bullet hit radius
            ampitude : 1.5f,
            bulletMotionType : BulletMotionType.RectilinearUniform,
            sourceBattleSide : characterEntityBattle.Character.CharacterComponentSide.BattleSide
        );

        // basic
        /*
        AddBullet(
            pos : characterEntityBattle.transform.position + offsetDefault,
            dir : Quaternion.Euler(0, 0, 0) * characterEntityBattle.CharacterComponentModel.Model.forward, // bullet direction offset z
            scale : scaleDefault * 0.3f, // bullet visual radius
            rot : rotDefault,
            speedMovement : 5f,
            ttl : 10f,
            radiusHit : 0.2f, // bullet hit radius
            bulletMotionType : BulletMotionType.RectilinearUniform,
            sourceBattleSide : characterEntityBattle.Character.CharacterComponentSide.BattleSide
        );
        */


    }

    public void AddBullet(
        Vector3 pos, 
        Vector3 dir, 
        Vector3 scale,
        Vector3 center,
        Quaternion rot,
        float speedMovement, 
        float ttl,
        float radiusHit,
        float ampitude,
        BulletMotionType bulletMotionType,
        BattleSide sourceBattleSide)
    {
        listBulletStruct.Add(new BulletStruct 
        {
            Pos = pos,
            Dir = dir,
            Scale = scale,
            Rot = rot,
            Center = pos,
            SpeedMovement = speedMovement,
            Ttl = ttl,
            RadiusHit = radiusHit,
            Amplitude = ampitude,
            BulletMotionType = bulletMotionType,
            SourceBattleSide = sourceBattleSide
        });
    }
}
