using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Aremoreno.Enums.Battle;

public class BattleComponentTarget
{
    private Battle battle;
    private BattleComponentIndicatorTarget battleComponentIndicatorTarget;

    private Team team;
    private CharacterEntityBattle entityTarget;
    private int teamCount;
    private int characterCount;
    private int indexTargetTeam;
    private int indexTargetCharacter;

    public BattleComponentTarget(Battle battle, BattleComponentIndicatorTarget battleComponentIndicatorTarget)
    {
        this.battle = battle;
        this.battleComponentIndicatorTarget = battleComponentIndicatorTarget;
    }

    public void Clear() 
    {
        team = null;
        entityTarget = null;
    }

    public void ChangeTargetNext(CharacterEntityBattle entityTargeter)
    {
        teamCount = battle.BattleComponentTeam.DictTeam.Count;
        indexTargetTeam = entityTargeter.CharacterComponentTarget.IndexTargetTeam + 1;
        indexTargetCharacter = entityTargeter.CharacterComponentTarget.IndexTargetCharacter + 1;
        if (indexTargetTeam >= teamCount) indexTargetTeam = 0;

        while (indexTargetTeam < teamCount) 
        {
            team = battle.BattleComponentTeam.DictTeam.ElementAt(indexTargetTeam).Value;
            characterCount = team.TeamComponentCharacter.ListCharacterPointEntity.Count;
            if (indexTargetCharacter >= characterCount) indexTargetCharacter = 0;
            while (indexTargetCharacter < characterCount) 
            {
                entityTarget = team.TeamComponentCharacter.ListCharacterPointEntity[indexTargetCharacter];
                if (CanTarget(entityTargeter, entityTarget)) 
                {
                    ChangeTarget(entityTargeter, entityTarget, indexTargetTeam, indexTargetCharacter);
                    return;
                }
                indexTargetCharacter++;
            }
            indexTargetTeam++;
            if (indexTargetTeam >= teamCount) indexTargetTeam = 0;
        }
    }

    public void ChangeTargetPrev(CharacterEntityBattle entityTargeter)
    {
        teamCount = battle.BattleComponentTeam.DictTeam.Count;
        indexTargetTeam = entityTargeter.CharacterComponentTarget.IndexTargetTeam - 1;
        indexTargetCharacter = entityTargeter.CharacterComponentTarget.IndexTargetCharacter - 1;
        if (indexTargetTeam < 0) indexTargetTeam = teamCount - 1;

        while (indexTargetTeam >= 0) 
        {
            team = battle.BattleComponentTeam.DictTeam.ElementAt(indexTargetTeam).Value;
            characterCount = team.TeamComponentCharacter.ListCharacterPointEntity.Count;
            if (indexTargetCharacter < 0) indexTargetCharacter = characterCount - 1;
            while (indexTargetCharacter >= 0) 
            {
                entityTarget = team.TeamComponentCharacter.ListCharacterPointEntity[indexTargetCharacter];
                if (CanTarget(entityTargeter, entityTarget)) 
                {
                    ChangeTarget(entityTargeter, entityTarget, indexTargetTeam, indexTargetCharacter);
                    return;
                }
                indexTargetCharacter--;
            }
            indexTargetTeam--;
            if (indexTargetTeam < 0) indexTargetTeam = teamCount - 1;
        }
    }

    public void ChangeTargetDefault(CharacterEntityBattle entityTargeter)
    {
        indexTargetTeam = (int) entityTargeter.Character.CharacterComponentSide.BattleSide + 2;
        indexTargetCharacter = entityTargeter.Character.CharacterComponentSide.EntityIndex;

        entityTargeter.CharacterComponentTarget.SetIndexTargetTeam(indexTargetTeam);
        entityTargeter.CharacterComponentTarget.SetIndexTargetCharacter(indexTargetCharacter);

        teamCount = battle.BattleComponentTeam.DictTeam.Count;
        if (indexTargetTeam >= teamCount) indexTargetTeam = 0;

        team = battle.BattleComponentTeam.DictTeam.ElementAt(indexTargetTeam).Value;
        characterCount = team.TeamComponentCharacter.ListCharacterPointEntity.Count;
        if (indexTargetCharacter >= characterCount) indexTargetCharacter = 0;
        entityTarget = team.TeamComponentCharacter.ListCharacterPointEntity[indexTargetCharacter];
        if (!CanTarget(entityTargeter, entityTarget)) 
            ChangeTargetNext(entityTargeter);

        ChangeTarget(entityTargeter, entityTarget, indexTargetTeam, indexTargetCharacter);
    }

    private void ChangeTarget(CharacterEntityBattle entityTargeter, CharacterEntityBattle entityTarget, int indexTargetTeam, int indexTargetCharacter)
    {
        if (entityTargeter.Character.CharacterComponentSide.BattleSide == battle.BattleComponentTeam.BattleSideUser)
            battleComponentIndicatorTarget.SetIndicator(entityTarget);

        entityTargeter.CharacterComponentTarget.SetTargetEntity(entityTarget);
        entityTargeter.CharacterComponentTarget.SetIndexTargetTeam(indexTargetTeam);
        entityTargeter.CharacterComponentTarget.SetIndexTargetCharacter(indexTargetCharacter);
    }

    private bool CanTarget(CharacterEntityBattle entityTargeter, CharacterEntityBattle entityTarget)
    {
        return !entityTargeter.Character.CharacterComponentSide.IsSameTeam(entityTarget.Character);
    }
}
