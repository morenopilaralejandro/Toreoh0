using UnityEngine;
using Unity.Cinemachine;

public class Battle 
{
    public BattleComponentConfig BattleComponentConfig;
    public BattleComponentAttributes BattleComponentAttributes;
    public BattleComponentField BattleComponentField;
    public BattleComponentTeam BattleComponentTeam;
    public BattleComponentCharacter BattleComponentCharacter;
    public BattleComponentPersistence BattleComponentPersistence;
    public BattleComponentEnd BattleComponentEnd;
    public BattleComponentTarget BattleComponentTarget;
    public BattleComponentCamera BattleComponentCamera;
    public BattleComponentBullet BattleComponentBullet;
    public BattleComponentDamageCalculator BattleComponentDamageCalculator;

    public Battle(
        BattleConfig battleConfig, 
        CinemachineTargetGroup cinemachineTargetGroup,
        BattleComponentIndicatorTarget battleComponentIndicatorTarget,
        Transform tileMapParent,
        Transform parentProtectObstacle,
        Transform parentBarrier,
        Transform parentCharacter)
    {
        BattleComponentConfig = new BattleComponentConfig(battleConfig);
        BattleComponentAttributes = new BattleComponentAttributes();
        BattleComponentTarget = new BattleComponentTarget(this, battleComponentIndicatorTarget);
        BattleComponentField = new BattleComponentField(this, tileMapParent, parentProtectObstacle, parentBarrier);
        BattleComponentTeam = new BattleComponentTeam(this);
        BattleComponentCharacter = new BattleComponentCharacter(this, parentCharacter);
        BattleComponentPersistence = new BattleComponentPersistence(this);
        BattleComponentEnd = new BattleComponentEnd(this);
        BattleComponentCamera = new BattleComponentCamera(this, cinemachineTargetGroup);
        BattleComponentBullet = new BattleComponentBullet(this, battleConfig);
        BattleComponentDamageCalculator = new BattleComponentDamageCalculator(this, battleConfig);
    }

    public void Dispose() 
    {
        BattleComponentField.Dispose();
        BattleComponentCharacter.Dispose();
    }

    public void UpdateInternal() 
    {
        BattleComponentBullet.UpdateInternal();
    }
}
