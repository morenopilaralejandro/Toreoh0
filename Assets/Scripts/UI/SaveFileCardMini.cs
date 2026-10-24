using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using System;
using TMPro;

public class SaveFileCardMini : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroupNoData;
    [SerializeField] private CanvasGroup canvasGroupAuto;
    [SerializeField] private int maxHour;
    [SerializeField] private TMP_Text textIndex;
    [SerializeField] private TMP_Text textPlayTime;
    [SerializeField] private TMP_Text textTimestampSave;
    [SerializeField] private Image imageGameClear;

    public void SetData(SaveData saveData)
    {
        UIUtils.SetCanvasGroupAlpha(canvasGroupNoData, 0f);
        textPlayTime.text = GetPlayTimeFormated(saveData.PlayTimeSaveData.PlayTimeSeconds);
        textTimestampSave.text = GetTimestampSaveFormated(saveData.PlayTimeSaveData.TimestampSave);
    }

    public void SetIndex(int index)
    {
        textIndex.text = index.ToString();
        UIUtils.SetCanvasGroupAlpha(canvasGroupAuto, index == 0);
    }

    public void Clear()
    {
        UIUtils.SetCanvasGroupAlpha(canvasGroupNoData, 1f);
        textIndex.text = string.Empty;
        textPlayTime.text = string.Empty;
        textTimestampSave.text = string.Empty;
    }

    private string GetPlayTimeFormated(long playTimeSeconds)
    {
        int totalMinutes = (int)(playTimeSeconds / 60);
        int hour = totalMinutes / 60;
        int minute = totalMinutes % 60;
        if (hour > maxHour) hour = maxHour;
        return $"{hour}:{minute:D2}";
    }

    private string GetTimestampSaveFormated(long timestampSave)
    {

        TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestampSave);
        DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTimeOffset.UtcDateTime, timeZoneInfo);
        var currentCultureInfo = LocalizationSettings.SelectedLocale.Identifier.CultureInfo;
        string date = dateTime.ToString("d", currentCultureInfo);
        string time = dateTime.ToString("HH:mm", currentCultureInfo);
        return $"{date} {time}";
    }
}
