using Aremoreno.Enums.Battle;

public class CharacterComponentAttributes
{
    public string CharacterId;
    public string CharacterGuid;

    public CharacterComponentAttributes(CharacterData data) 
    {
        CharacterId = data.CharacterId;
        CharacterGuid = data.CharacterId;
    }
}
