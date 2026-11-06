using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

public class BattleComponentTarget
{
    private Battle battle;
    public List<CharacterEntityBattle> ListTarget = new ();
    public CharacterEntityBattle TargetEntity;
    private int count;
    private int targetIndex;
    private BattleComponentIndicatorTarget battleComponentIndicatorTarget;

    /*
        any point entity can be targeted
        exclude user side when creating it



        have a monobehaviur component for the indicator and call it
        set as children off that chanracer

        probably recibe it in the constructor from manager
        probably recibe camera thing in contrustor from manager

    */

    public BattleComponentTarget(Battle battle, BattleComponentIndicatorTarget battleComponentIndicatorTarget)
    {
        this.battle = battle;
        this.battleComponentIndicatorTarget = battleComponentIndicatorTarget;
    }

    public void Initialize()
    {
        foreach (var team in battle.BattleComponentTeam.DictTeam.Values)
        {
            foreach (var character in team.TeamComponentCharacter.ListCharacterPointEntity)
            {
                if (character.Character.CharacterComponentSide.BattleSide != battle.BattleComponentTeam.BattleSideUser)
                    ListTarget.Add(character);
            }
        }
        count = ListTarget.Count;
        ChangeTargetDefault();
    }

    public void ChangeTargetDefault() => ChangeTarget(0);
    public void ChangeTargetNext() => ChangeTarget(targetIndex++);
    public void ChangeTargetPrev() => ChangeTarget(targetIndex--);

    private void ChangeTarget(int targetIndex)
    {
        if (targetIndex < 0) targetIndex = count;
        if (targetIndex > count) targetIndex = 0;

        TargetEntity = ListTarget[targetIndex];
        battle.BattleComponentCamera.AddMemberSub(TargetEntity.transform);
        battleComponentIndicatorTarget.SetIndicator(TargetEntity);
    }

    public void Clear() 
    {
        ListTarget.Clear();
        count = 0;
        targetIndex = 0;
        TargetEntity = null;
    }
}
