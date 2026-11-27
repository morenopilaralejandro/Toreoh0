using System.Collections.Generic;
using Aremoreno.Enums.Battle;

[System.Serializable]
public struct BattleMessageMapping
{
    public BattleMessage BattleMessage;
    public float Duration;
    public List<LocalizationReferenceStyleMapping> ListMappingReference;
}
