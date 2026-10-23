using UnityEngine;

public class OverviewSaveData : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private SaveFileCard card;

    private void SetData(SaveData saveData) 
    {
        card.SetData(saveData);
    }

    private void Clear() 
    {
        card.Clear();
    }

    private void OnEnable()
    {
        UIEvents.OnSaveDataOverviewUpdateRequested += OnSaveDataOverviewUpdateRequested;
    }

    private void OnDisable()
    {
        UIEvents.OnSaveDataOverviewUpdateRequested -= OnSaveDataOverviewUpdateRequested;
    }

    private void OnSaveDataOverviewUpdateRequested(SaveData saveData) 
    {
        if (!canvasGroup.interactable) return;
        if (saveData == null)
            Clear();
        else
            SetData(saveData);
    }
}
