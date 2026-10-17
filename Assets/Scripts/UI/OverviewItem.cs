using UnityEngine;
using System.Threading.Tasks;

public class OverviewItem : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CanvasGroup canvasGroupIcon;
    [SerializeField] private ItemUI itemUI;

    private async Task SetData(Item item) 
    {
        await itemUI.SetAsync(item);
        UIUtils.SetCanvasGroupVisible(canvasGroupIcon, true);
    }

    private void Clear() 
    {
        itemUI.Clear();
        UIUtils.SetCanvasGroupVisible(canvasGroupIcon, false);
    }

    private void OnEnable()
    {
        UIEvents.OnItemOverviewUpdateRequested += OnItemOverviewUpdateRequested;
    }

    private void OnDisable()
    {
        UIEvents.OnItemOverviewUpdateRequested -= OnItemOverviewUpdateRequested;
    }

    private async void OnItemOverviewUpdateRequested(Item item) 
    {
        if (!canvasGroup.interactable) return;
        if (item == null)
            Clear();
        else
            await SetData(item);
    }
}
