using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Character;

public class StatsDict
{
    public Dictionary<Stat, int> Dict = new ();

    public StatsDict() {}
    public StatsDict(List<StatsScalingMapping> listStatsScalingMapping, int statValue = 0) 
    {
        foreach (var mapping in listStatsScalingMapping)
            Dict[mapping.Stat] = statValue;
    }
    public StatsDict(List<Stat> listStat, int statValue = 0) 
    {
        foreach (var stat in listStat) 
            Dict[stat] = statValue;
    }

    public void Clear() => Dict.Clear();
    public void Reset(int statValue = 0) 
    {
        foreach (var kvp in Dict) 
            Dict[kvp.Key] = statValue;
    }

    public int Get(Stat stat) => Dict[stat];
    public void Set(Stat stat, int statValue) => Dict[stat] = statValue;
    public void Modify(Stat stat, int statValue) => Dict[stat] += statValue;
    public void Clamp(Stat stat, int statValueMin, int statValueMax) => Dict[stat] = Mathf.Clamp(Dict[stat], statValueMin, statValueMax);

    public int Scale(StatsScalingMapping mapping, int statValueBase, int level, int levelMax) => Scale(statValueBase, level, levelMax, mapping.ScalingStrategy, mapping.ScalingRatioMin, mapping.ScalingRatioMax, mapping.ScalingExponent);
    public int Scale(
        int statValueBase, // can be base stat + individual stat
        int level, 
        int levelMax, 
        ScalingStrategy scalingStrategy, 
        float scalingRatioMin, 
        float scalingRatioMax, 
        int scalingExponent)
    {
        float statValue = 0;
        float t = (float) (level -1) / (levelMax -1);
        switch(scalingStrategy)
        {
            case ScalingStrategy.Linear:
                statValue = statValueBase * Mathf.Lerp(scalingRatioMin, scalingRatioMax, t);
                break;
            case ScalingStrategy.Exponential:
                t = Mathf.Pow(t, scalingExponent);
                statValue = statValueBase * Mathf.Lerp(scalingRatioMin, scalingRatioMax, t);
                break;
        }
        return Mathf.FloorToInt(statValue);
    }
}
