using System.Buffers;
using System.Collections.Generic;
using Aremoreno.Enums.Localization;
using Aremoreno.Enums.Dialog;

public class DialogLocalizationBridge 
{
    private LocalizationComponentString localizationComponent;
    private Dictionary<string, object> dictArguments = new ();

    // resolve
    public string ResolveDialogText(DialogSerializableLine line)
    {
        UpdateLocalization(LocalizationEntity.Dialog, line.LocalizationKey, LocalizationField.Text);
        SetArguments(LocalizationField.Text);
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

    public string ResolveItemName(string itemId) 
    {
        UpdateLocalization(LocalizationEntity.Item, itemId, LocalizationField.Name);
        return localizationComponent.GetString(LocalizationField.Name);
    }

    // update
    private void UpdateLocalization(LocalizationEntity entity, string id, LocalizationField field) 
    {
        localizationComponent = new LocalizationComponentString(
            entity,
            id,
            new LocalizationField[] { field }
        );
    }

    // args
    public void SetArgument(string argKey, object argVal) => dictArguments[argKey] = argVal;
    public void ClearArguments() => dictArguments.Clear();
    private void SetArguments(LocalizationField field)
    {
        if(dictArguments.Count == 0) return;
        localizationComponent.SetArguments(field, new object[] { dictArguments });
    }
}
