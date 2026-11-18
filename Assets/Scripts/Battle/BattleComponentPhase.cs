using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Character;

public class BattleComponentPhase
{
    private Battle battle;
    public BattlePhase BattlePhaseCurrent;
    public BattlePhase BattlePhasePrev;

    public BattleComponentPhase(Battle battle)
    {
        this.battle = battle;

        BattlePhasePrev = BattlePhase.Captura;
        SetBattlePhase(BattlePhase.Varas);
        //BattlePhase = BattlePhase.Varas;
    }

    public void SetBattlePhase(BattlePhase battlePhase) 
    {
        BattlePhasePrev = BattlePhaseCurrent;
        BattlePhaseCurrent = battlePhase;
        BattleEvents.RaiseBattlePhaseChanged(BattlePhaseCurrent, BattlePhasePrev);
    }

    // event
    public void Subscribe()
    {               
        UIEvents.OnCharacterHpDecreased += OnCharacterHpDecreased;
    }

    public void Unsubscribe()
    {
        UIEvents.OnCharacterHpDecreased -= OnCharacterHpDecreased;
    }

    private void OnCharacterHpDecreased(CharacterEntityBattle entity) 
    {
        if (entity.Character.CharacterComponentSide.IsSameTeam(battle.BattleComponentTeam.BattleSideUser)) return;

        float hpNormalized = entity.Character.CharacterComponentStats.GetStatNormalized(Stat.Hp);
        if (hpNormalized <= 0) return;
        foreach (var mapping in battle.BattleComponentConfig.BattleConfig.ListBattlePhaseMapping) 
        {
            if (hpNormalized < mapping.ThresholdHp) 
            {
                SetBattlePhase(mapping.BattlePhase);
                break;
            }
        }
    }
}
