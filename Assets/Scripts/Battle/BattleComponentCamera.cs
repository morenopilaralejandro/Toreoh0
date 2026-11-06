using UnityEngine;
using Unity.Cinemachine;
using Aremoreno.Enums.Battle;

public class BattleComponentCamera
{
    private Battle battle;
    private CinemachineTargetGroup cinemachineTargetGroup;

    public BattleComponentCamera(Battle battle, CinemachineTargetGroup cinemachineTargetGroup)
    {
        this.battle = battle;
        this.cinemachineTargetGroup = cinemachineTargetGroup;
    }

    public void AddMemberMain(Transform transformMember) 
    {
        cinemachineTargetGroup.Targets[0].Object = transformMember;
    }

    public void AddMemberSub(Transform transformMember)
    {
        cinemachineTargetGroup.Targets[1].Object = transformMember;
    }
}
