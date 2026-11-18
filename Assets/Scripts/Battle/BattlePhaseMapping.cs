using System.Collections.Generic;
using Aremoreno.Enums.Battle;

[System.Serializable]
public class BattlePhaseMapping
{
    public BattlePhase BattlePhase;
    public float ThresholdHp;
    public List<LocalizationReferenceStyleMapping> ListLocalizationReferenceStyleMapping;
}
