using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Bullet;

public class BattleComponentBullet
{
    private Battle battle;
    private List<BulletStruct> listBulletStruct = new ();
    private float sqrMagnitude;
    private RenderParams renderParams;
    private MaterialPropertyBlock matProps;
    private Mesh mesh;
    private Material material;
    private Vector3 scaleDefault = new Vector3(1f, 1f, 0f);
    private Vector3 offsetDefault = new Vector3(0f, 0f, -0.5f);
    private Quaternion rotDefault = Quaternion.identity;

    public BattleComponentBullet(Battle battle, BattleConfig battleConfig)
    {
        this.battle = battle;
        this.mesh = battleConfig.MeshBullet;
        this.material = battleConfig.MaterialBullet;
        renderParams = new RenderParams(material);
    }

    public void AddBullet(CharacterEntityBattle characterEntityBattle)
    {
        // patter build a dict at start up from the database
        // get the pattern from the move
        // add one for each bullet in the pattern
        AddBullet(
            characterEntityBattle.transform.position + offsetDefault,
            characterEntityBattle.CharacterComponentModel.Model.forward,
            5f,
            10f
        );
        AddBullet(
            characterEntityBattle.transform.position + offsetDefault,
            characterEntityBattle.CharacterComponentModel.Model.forward + new Vector3(1f, 0f, 0f),
            5f,
            10f
        );
        AddBullet(
            characterEntityBattle.transform.position + offsetDefault,
            characterEntityBattle.CharacterComponentModel.Model.forward + new Vector3(-1f, 0f, 0f),
            5f,
            10f
        );
        AddBullet(
            characterEntityBattle.transform.position + offsetDefault,
            characterEntityBattle.CharacterComponentModel.Model.forward * -1,
            5f,
            10f
        );
    }

    public void AddBullet(Vector3 pos, Vector3 dir, float speed, float ttl)
    {
        listBulletStruct.Add(new BulletStruct 
        {
            Pos = pos,
            Dir = dir,
            SpeedMovement = 1f,
            Ttl = 9999f,
            Rot = rotDefault,
            Scale = scaleDefault
        });
    }

    public void UpdateInternal() 
    {
        UpdateActive();
        UpdateDestroyed();
    }

    public void UpdateActive() 
    {
        for(int i = 0; i < listBulletStruct.Count; i++)
        {
            BulletStruct bulletStruct = listBulletStruct[i];
            
            // ttl
            bulletStruct.Ttl -= Time.deltaTime;
            if (bulletStruct.Ttl <= 0) 
                bulletStruct.BulletState = BulletState.Destroyed;

            // collision obstacle
            /*
            if (Physics.CheckSphere(bulletStruct.Pos, bulletStruct.Radius, layerObstacle)) 
                bulletStruct.BulletState = BulletState.Destroyed;
            */
            
            if (bulletStruct.BulletState == BulletState.Destroyed) continue;
                
            // position            
            bulletStruct.Pos += bulletStruct.Dir.normalized * bulletStruct.SpeedMovement * Time.deltaTime;
            bulletStruct.Pos.z = -0.5f;

            // draw
            Graphics.RenderMesh(renderParams, mesh, 0, Matrix4x4.TRS(bulletStruct.Pos, bulletStruct.Rot, bulletStruct.Scale));

            /*
            matProps.SetColor();
            propertyBlock.SetColor("_BaseColor", lineColor);

            matProps.SetTexture();
            matProps.SetTexture("_BaseMap", texture);

            renderParams.matProps = matProps;

            */




            // collision character
            foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
            {
                foreach (CharacterEntityBattle entity in team.TeamComponentCharacter.ListCharacterPointEntity)
                {
                    sqrMagnitude = (bulletStruct.Pos - entity.transform.position).sqrMagnitude;
                    if (sqrMagnitude < 2f * 2f) {
                        //CustomLog.Error($"Collision with {entity.Character.CharacterComponentAttributes.CharacterId}");
                    }
                }
            }


            





            /*
            if (Physics.CheckSphere(bulletStruct.Pos, bulletStruct.Radius, layerObstacle)) 
            {
                bulletStruct.BulletState = Destroyed;
            }
            

            Ray ray = new Ray(previousPos, direction);
            if (Physics.Raycast(ray, out var hit, distance)) {
                // Bullet hit detected
            }




            // in character cache characterHitRadiusSquare
            // here use a variable for bulletStruct.Pos - entity.transform.position
            if ((bulletStruct.Pos - entity.transform.position).sqrMagnitude < characterHitRadius * characterHitRadius) {
                // Bullet collided with enemy
            }

            if ((bulletStruct.Pos - entity.transform.position).sqrMagnitude < characterGraceRadius * characterGraceRadius) {
                // Bullet collided with enemy
            }




            if (Physics.CheckSphere(bulletStruct.Pos, bulletStruct.Radius, layerCharacter)) 
            {
                damage - what target???? -> put this in the character entity and check side
            }


            if (Physics.CheckSphere(bulletStruct.Pos, bulletStruct.Radius, layerBullet))
            {
                damage - what target???? -> put this in the character entity and check side
            }
            */

            listBulletStruct[i] = bulletStruct;


        }
    }

    private void UpdatePosition(BulletStruct bulletStruct) 
    {
        // change to calulate the vector 3
    }

    private void UpdateTtl(BulletStruct bulletStruct) 
    {

    }

    private void UpdateCollision(BulletStruct bulletStruct) 
    {
        // if player, damage
        // if obstacle, destroy
    }

    private void UpdateDestroyed() 
    {
        for(int i = listBulletStruct.Count - 1; i >= 0; i--)
        {
            if (listBulletStruct[i].BulletState == BulletState.Destroyed)
                listBulletStruct.RemoveAt(i);
        }
    }
}
