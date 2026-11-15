using Aremoreno.Enums.Character;

[System.Serializable]
public class StatsScalingMapping
{
    public Stat Stat;
    public ScalingStrategy ScalingStrategy;
    public float ScalingRatioMin;
    public float ScalingRatioMax;
    public int ScalingExponent;
}
