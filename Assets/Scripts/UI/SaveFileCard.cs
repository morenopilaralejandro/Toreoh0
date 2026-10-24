using UnityEngine;
using TMPro;
using Aremoreno.Enums.Localization;

public class SaveFileCard : MonoBehaviour
{
    [SerializeField] private TMP_Text textZoneName;
    private LocalizationComponentString localizationStringComponentZone;

    public void SetData(SaveData saveData)
    {
        UpdateZoneName(saveData.WorldManagerSaveData.ZoneId);
    }

    public void Clear()
    {
        textZoneName.text = string.Empty;
    }

    private void UpdateZoneName(string id)
    {
        localizationStringComponentZone = new LocalizationComponentString(
            LocalizationEntity.Zone,
            id,
            new [] { LocalizationField.Name }
        );
        textZoneName.text = localizationStringComponentZone.GetString(LocalizationField.Name);
    }
}
