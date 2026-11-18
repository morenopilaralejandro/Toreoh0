using Aremoreno.Enums.Character;

public class CharacterComponentAIScalingDifficulty
{
    private Character character;
    public AIDifficulty AIDifficulty;

    public CharacterComponentAIScalingDifficulty(Character character) 
    {
        this.character = character;
    }

    public void ScaleByLevel(int level) 
    {
        foreach (var mapping in character.CharacterComponentConfig.Config.ListScalingDifficultyMapping) 
        {
            if (level < mapping.Level) 
            {
                AIDifficulty = mapping.AIDifficulty;
                break;
            }
        }

        ScaleAllSystems();
    }

    public void ScaleAllSystems() 
    {
        this.character.CharacterComponentAIScalingHp.Scale();
        // character CharacterComponentAIScalingWing, moves, etc
    }
}
