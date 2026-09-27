using Aremoreno.Enums.Localization;
using Aremoreno.Enums.Dialog;

public class DialogLocalizationBridge 
{
    private LocalizationComponentString localizationComponent;

    public string ResolveDialogText(DialogSerializableLine line)
    {
        UpdateLocalization(LocalizationEntity.Dialog, line.LocalizationKey, LocalizationField.Text);
        return localizationComponent.GetString(LocalizationField.Text);
    }

    public string ResolveChoiceText(DialogSerializableChoice choice) 
    {
        UpdateLocalization(LocalizationEntity.Dialog, choice.LocalizationKey, LocalizationField.Text);
        return localizationComponent.GetString(LocalizationField.Text);
    }

    public string ResolveSpeakerName(Speaker speaker) 
    {
        LocalizationEntity localizationEntity = default;
        LocalizationField localizationField = default;

        switch(speaker.AttributesComponent.SpeakerType)
        {
            case SpeakerType.Character:
                localizationEntity = LocalizationEntity.Character;
                localizationField = LocalizationField.Nick;
                break;
            case SpeakerType.Npc:
                localizationEntity = LocalizationEntity.Npc;
                localizationField = LocalizationField.Name;
                break;
        }
        UpdateLocalization(localizationEntity, speaker.AttributesComponent.SpeakerId, localizationField);
        return localizationComponent.GetString(localizationField);
    }

    private void UpdateLocalization(LocalizationEntity entity, string id, LocalizationField field) 
    {
        localizationComponent = new LocalizationComponentString(
            entity,
            id,
            new[] { field }
        );
    }
}
