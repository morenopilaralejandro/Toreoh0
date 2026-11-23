using System;

public class CharacterComponentStatsMp
{
    private Character character;

    public int BattleMp;
    private int mpMin = 0;
    private int mpMax = 100;
    private int mpDelta = 1;

    public CharacterComponentStatsMp(CharacterData data, Character character, CharacterSaveData saveData)
    {
        this.character = character;
    }

    public float GetMpNormalized() => (float) BattleMp / mpMax;

    public void ModifyMpWithClamp(int statValue) 
    {
        BattleMp += statValue;
        BattleMp = Math.Clamp(BattleMp, mpMin, mpMax);
    }

    public void IncreaseWithGrace() => ModifyMpWithClamp(mpDelta);

    public bool IsAffordable(int cost) => BattleMp >= cost;
}

