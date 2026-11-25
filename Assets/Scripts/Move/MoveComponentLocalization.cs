using Aremoreno.Enums.Localization;

public class MoveComponentLocalization 
{
    private LocalizationComponentString localizationStringComponent;

    public MoveComponentLocalization(MoveData data) 
    {
        localizationStringComponent = new LocalizationComponentString(
            LocalizationEntity.Move,
            data.MoveId,
            new [] { 
                LocalizationField.Name,
                LocalizationField.Description
            }
        );
    }

    public string Name => localizationStringComponent.GetString(LocalizationField.Name);
    public string Description => localizationStringComponent.GetString(LocalizationField.Description);
}
