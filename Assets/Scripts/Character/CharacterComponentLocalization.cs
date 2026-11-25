using Aremoreno.Enums.Localization;

public class CharacterComponentLocalization 
{
    private LocalizationComponentString localizationStringComponent;

    public CharacterComponentLocalization(CharacterData data) 
    {
        localizationStringComponent = new LocalizationComponentString(
            LocalizationEntity.Character,
            data.CharacterId,
            new [] { 
                LocalizationField.Name,
                LocalizationField.Nick,
                LocalizationField.Description
            }
        );
    }

    public string Name => localizationStringComponent.GetString(LocalizationField.Name);
    public string Nick => localizationStringComponent.GetString(LocalizationField.Nick);
    public string Description => localizationStringComponent.GetString(LocalizationField.Description);
}
