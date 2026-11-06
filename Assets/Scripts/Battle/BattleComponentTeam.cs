using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;

public class BattleComponentTeam
{
    private Battle battle;
    public BattleSide BattleSideUser = BattleSide.South;
    public Dictionary<BattleSide, Team> DictTeam = new ();

    public BattleComponentTeam(Battle battle)
    {
        this.battle = battle;

        InitializeFromData(BattleArgs.TeamNorthId, BattleSide.North);
        InitializeFromData(BattleArgs.TeamSouthId, BattleSide.South);

        InitializeFromSaveData(BattleArgs.TeamNorthSaveData, BattleSide.North);
        InitializeFromSaveData(BattleArgs.TeamSouthSaveData, BattleSide.South);
    }

    /*
        for each team
        if id initialize by data
        if save data intialize by save data
    */

    private void InitializeFromData(string id, BattleSide side) 
    {
        if (string.IsNullOrEmpty(id)) return;
        DictTeam[side] = TeamFactory.CreateById(id);
        DictTeam[side].TeamComponentSide.SetBattleSide(side);
    }

    private void InitializeFromSaveData(TeamSaveData saveData, BattleSide side) 
    {
        if (saveData == null) return;
        //DictTeam[side] = TeamFactory.CreateById(id);
        DictTeam[side].TeamComponentSide.SetBattleSide(side);
    }

    public void SetBattleSideUser(BattleSide battleSideUser) => BattleSideUser = battleSideUser;

    public void EnableControlledCharacter() 
    {
        DictTeam[BattleSideUser].TeamComponentCharacter.ListCharacterPointEntity[0].SetControllerEnable(true);
        battle.BattleComponentCamera.AddMemberMain(DictTeam[BattleSideUser].TeamComponentCharacter.ListCharacterPointEntity[0].transform);
    }

    public void Clear() 
    {
        DictTeam.Clear();
    }
}
