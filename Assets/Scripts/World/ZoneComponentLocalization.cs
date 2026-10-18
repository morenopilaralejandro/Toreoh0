using Aremoreno.Enums.Localization;

public class ZoneComponentLocalization 
{
    private LocalizationComponentString localizationStringComponent;

    public ZoneComponentLocalization(ZoneData zoneData) 
    {
        localizationStringComponent = new LocalizationComponentString(
            LocalizationEntity.Zone,
            zoneData.ZoneId,
            new [] { LocalizationField.Name }
        );
    }

    public string ZoneName => localizationStringComponent.GetString(LocalizationField.Name);
}
