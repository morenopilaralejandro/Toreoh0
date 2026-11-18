using System.Collections.Generic;
using Aremoreno.Enums.Character;
using Aremoreno.Enums.Duel;
using Aremoreno.Enums.Move;

public class CharacterComponentStats
{
    private Character character;

    public List<StatsScalingMapping> ListStatsScalingMapping;
    public StatsDict StatsBase = new StatsDict();
    public StatsDict StatsTrue = new StatsDict();
    public StatsDict StatsBattle = new StatsDict();
    public StatsDict StatsIndividual = new StatsDict();
    public StatsDict StatsTraining = new StatsDict();

    public CharacterComponentStats(CharacterData data, Character character, CharacterSaveData saveData)
    {
        this.character = character;
        ListStatsScalingMapping = character.CharacterComponentConfig.Config.ListStatsScalingMapping;

        foreach (var mapping in ListStatsScalingMapping) 
        {
            StatsTrue.Set(mapping.Stat, 0);
            StatsBattle.Set(mapping.Stat, 0);
            StatsIndividual.Set(mapping.Stat, 0);
            StatsTraining.Set(mapping.Stat, 0);
        }

        StatsBase.Set(Stat.Hp, data.StatHp);
        StatsBase.Set(Stat.MeleeAttack, data.StatMeleeAttack);
        StatsBase.Set(Stat.MeleeDefense, data.StatMeleeDefense);
        StatsBase.Set(Stat.RangeAttack, data.StatRangeAttack);
        StatsBase.Set(Stat.RangeDefense, data.StatRangeDefense);
        StatsBase.Set(Stat.Speed, data.StatSpeed);

        // TODO use save data
        RecalculateStats();
        // TODO set battle hp and sp from save data
    }

    // restore
    public void RestoreHpAndMp() 
    {
        StatsBattle.Set(Stat.Hp, StatsTrue.Get(Stat.Hp));
        // StatsBattle.Set(Stat.Mp, StatTrue.Get(Stat.Mp));
    }   

    // get stat special
    public float GetStatNormalized(Stat stat) => (float) StatsBattle.Get(stat) / StatsTrue.Get(stat);

    public float GetStatValueByDuelRoleAndMoveCategory(DuelRole duelRole, MoveCategory moveCategory) => (float) StatsBattle.Get(GetStatByDuelRoleAndMoveCategory(duelRole,moveCategory));
    public Stat GetStatByDuelRoleAndMoveCategory(DuelRole duelRole, MoveCategory moveCategory) 
    {
        if (duelRole == DuelRole.Offense) 
        {
            if (moveCategory == MoveCategory.Range)
                return Stat.RangeAttack;
            else
                return Stat.MeleeAttack;
        } else 
        {
            if (moveCategory == MoveCategory.Range)
                return Stat.RangeDefense;
            else
                return Stat.MeleeDefense;
        }
    }

    // logic
    public void ModifyStatsBattleWithClamp(Stat stat, int statValue) 
    {
        StatsBattle.Modify(stat, statValue);
        StatsBattle.Clamp(stat, 0, StatsTrue.Get(stat));
        // battle stat event CharacterHpDepleated (check all characters to check win condition)
    }

    public void RecalculateStats()
    {
        foreach (var mapping in ListStatsScalingMapping)
        {
            // scale stats and asign it to true stats
            StatsTrue.Set(
                mapping.Stat, 
                StatsBase.Scale(
                    mapping,
                    StatsBase.Get(mapping.Stat), // can add StatsIndividual.Get(mapping.Stat)
                    character.CharacterComponentLevel.Level,
                    character.CharacterComponentLevel.LevelMax
                )
            );

            // add training
            StatsTrue.Modify(mapping.Stat, StatsTraining.Get(mapping.Stat));

            // TODO add awaken
            // StatsTrue.Set(mapping.Stat, StatsTrue.Get(mapping.Stat) * character.CharacterComponentAwaken.AwakenMultiplierStat);

            // set battle stat = true stat 
            StatsBattle.Set(mapping.Stat, StatsTrue.Get(mapping.Stat));
        }      
    }
}
