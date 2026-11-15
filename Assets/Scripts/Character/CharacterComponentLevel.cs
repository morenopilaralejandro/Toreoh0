public class CharacterComponentLevel : CharacterComponentLevelBase
{
    public CharacterComponentLevel(Character character, CharacterSaveData saveData) : base(
        level : saveData != null ? 0 : character.CharacterComponentConfig.Config.LevelMin,
        xpCurrent : saveData != null ? 0 : 0,
        xpTotal : saveData != null ? 0 : 0,
        levelMin : character.CharacterComponentConfig.Config.LevelMin,
        levelMax : character.CharacterComponentConfig.Config.LevelMax, 
        scalingBase : character.CharacterComponentConfig.Config.ScalingBase, 
        scalingMultiplier : character.CharacterComponentConfig.Config.ScalingMultiplier, 
        scalingExponent : character.CharacterComponentConfig.Config.ScalingExponent, 
        scalingStrategy : character.CharacterComponentConfig.Config.ScalingStrategy
    ) { }

    public override void OnLevelUpPerformed()
    {

    }
}
