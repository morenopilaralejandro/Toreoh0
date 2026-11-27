using UnityEngine;
using Aremoreno.Enums.Character;

public class CharacterComponentAIScalingHp
{
    private Character character;
    private float multiplierHp = 2f; // 1.5f

    public CharacterComponentAIScalingHp(Character character) 
    {
        this.character = character;
    }

    public void Scale() 
    {
        this.character.CharacterComponentStats.StatsTrue.Set(Stat.Hp, (int) Mathf.Pow(this.character.CharacterComponentStats.StatsTrue.Get(Stat.Hp), multiplierHp));
        this.character.CharacterComponentStats.StatsBattle.Set(Stat.Hp, this.character.CharacterComponentStats.StatsTrue.Get(Stat.Hp));
    }
}
