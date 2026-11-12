using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Color;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "ScriptableObject/Color/ColorConfig")]
public class ColorConfig : ScriptableObject
{
    [Header("ColorDictionary")]
    public ColorDictionary<ColorGeneric> Color;
    public ColorDictionary<BattleMessage> BattleMessage;
    public ColorDictionary<BattleSide> BattleSide;
    public ColorDictionary<BattleSide> BattleSideBullet;

    public IEnumerable<IColorDictionary> GetAllDictionaries() 
    {
        yield return Color;
        yield return BattleMessage;
        yield return BattleSide;
        yield return BattleSideBullet; 
    }
}
