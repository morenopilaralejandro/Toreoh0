using Aremoreno.Enums.Localization;

public class ShopComponentLocalization 
{
    private LocalizationComponentString localizationStringComponent;

    public ShopComponentLocalization(ShopData data) 
    {
        localizationStringComponent = new LocalizationComponentString(
            LocalizationEntity.Shop,
            data.ShopId,
            new [] { LocalizationField.Name }
        );
    }

    public string ShopName => localizationStringComponent.GetString(LocalizationField.Name);
}
