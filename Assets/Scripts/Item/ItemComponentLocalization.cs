using Aremoreno.Enums.Localization;

public class ItemComponentLocalization 
{
    private LocalizationComponentString localizationStringComponent;

    public ItemComponentLocalization(ItemData data) 
    {
        localizationStringComponent = new LocalizationComponentString(
            LocalizationEntity.Item,
            data.ItemId,
            new [] { 
                LocalizationField.Name,
                LocalizationField.Description,
            }
        );
    }

    public string ItemName => localizationStringComponent.GetString(LocalizationField.Name);
    public string ItemDescription => localizationStringComponent.GetString(LocalizationField.Description);
}
