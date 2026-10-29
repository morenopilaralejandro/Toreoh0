using Aremoreno.Enums.Battle;

public class CharacterComponentAttributes
{
    public string CharacterId;

    public CharacterComponentAttributes(CharacterData data) 
    {
        CharacterId = data.CharacterId;
    }
}
