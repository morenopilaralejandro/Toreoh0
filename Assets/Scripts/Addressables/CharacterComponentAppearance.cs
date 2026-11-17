public class CharacterComponentAppearance
{
    public string AddressSpritePortrait;

    public CharacterComponentAppearance(CharacterData data) 
    {
        AddressSpritePortrait = AddressableBuilder.GetCharacterPortraitAddress(data.CharacterId);
    }
}
