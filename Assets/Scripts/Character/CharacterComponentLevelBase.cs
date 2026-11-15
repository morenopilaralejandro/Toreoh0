using UnityEngine;
using Aremoreno.Enums.Character;

public abstract class CharacterComponentLevelBase
{
    public int Level;
    public int LevelMin;
    public int LevelMax;
    public int XpCurrent;
    public int XpTotal;
    public int XpToNext;

    protected int scalingBase;
    protected int scalingMultiplier;
    protected int scalingExponent;
    protected ScalingStrategy scalingStrategy;

    // public event Action OnLevelUp;

    public CharacterComponentLevelBase(
        int level,
        int xpCurrent,
        int xpTotal,
        int levelMin,
        int levelMax, 
        int scalingBase, 
        int scalingMultiplier, 
        int scalingExponent,
        ScalingStrategy scalingStrategy)
    {
        Level = level;
        XpCurrent = xpCurrent;
        XpTotal = xpTotal;
        LevelMin = levelMin;
        LevelMax = levelMax;

        this.scalingBase = scalingBase;
        this.scalingMultiplier = scalingMultiplier;
        this.scalingExponent = scalingExponent;
        this.scalingStrategy = scalingStrategy;

        XpToNext = CalcXpToNext(Level, scalingStrategy);
    }

    public void AddXp(int count) 
    {
        if (Level >= LevelMax) return;
        XpTotal += count;
        XpCurrent += count;

        while (XpCurrent >= XpToNext && Level < LevelMax)
            LevelUp();
    }

    public void LevelUp() 
    {
        Level++;
        XpCurrent = 0;
        XpToNext = CalcXpToNext(Level, scalingStrategy);
        OnLevelUpPerformed();
    }

    public abstract void OnLevelUpPerformed();

    // warp in classes
    public void SetLevel(int level)
    {
        Level = level;
        XpToNext = CalcXpToNext(Level, scalingStrategy);
        OnLevelUpPerformed();
    }

    public int CalcXpToNext(int level, ScalingStrategy scalingStrategy)
    {
        switch(scalingStrategy)
        {
            case ScalingStrategy.Linear:
                return CalcXpToNextLinear(level);
            case ScalingStrategy.Exponential:
                return CalcXpToNextExponential(level);
        }
        return 0;
    }

    public int CalcXpToNextLinear(int level) 
    {
        return scalingBase + level * scalingMultiplier;
    }

    public int CalcXpToNextExponential(int level) 
    {
        return scalingBase + 
            Mathf.FloorToInt(
                Mathf.Pow(
                    level * scalingMultiplier, 
                    scalingExponent
                )
            );
    }
}
