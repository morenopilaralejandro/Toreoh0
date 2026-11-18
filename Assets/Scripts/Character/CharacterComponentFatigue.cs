using Aremoreno.Enums.Character;

public class CharacterComponentFatigue
{
    private Character character;

    public FatigueState FatigueState;
    public float FatigueMultiplier;

    public CharacterComponentFatigue(Character character)
    {
        this.character = character;
        // RecalculateFatigue();
        SetFatigueState(FatigueState.Normal);
    }

    public void SetFatigueState(FatigueState fatigueState) 
    {
        FatigueState = fatigueState;
        FatigueMultiplier = character.CharacterComponentConfig.Config.DictFatigueMapping[FatigueState].FatigueMultiplier;
    }

    private void RecalculateFatigue() 
    {
        float hp = character.CharacterComponentStats.StatsBattle.Get(Stat.Hp);
        foreach (var mapping in character.CharacterComponentConfig.Config.ListFatigueMapping) 
        {
            if (hp < mapping.ThresholdHp) 
            {
                FatigueState = mapping.FatigueState;
                FatigueMultiplier = mapping.FatigueMultiplier;
                break;
            }
        }
    }

    // event
    public void Subscribe()
    {               
        // UIEvents.OnCharacterHpDecreased += OnCharacterHpDecreased;
    }

    public void Unsubscribe()
    {
        // UIEvents.OnCharacterHpDecreased -= OnCharacterHpDecreased;
    }

    private void OnCharacterHpDecreased(CharacterEntityBattle entity) 
    {
        if (this.character.CharacterComponentAttributes.CharacterGuid != entity.Character.CharacterComponentAttributes.CharacterGuid) return;
    }
}
