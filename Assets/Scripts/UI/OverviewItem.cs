using UnityEngine;
using System.Threading.Tasks;

public class OverviewItem : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private ItemUI itemUI;

    private async Task SetData(Item item) 
    {
        await itemUI.SetAsync(item, ItemManager.Instance.StorageComponent.GetItemCount(item));
        UIUtils.SetCanvasGroupAlpha(canvasGroup, 1f);
    }

    private void Clear() 
    {
        itemUI.Clear();
        UIUtils.SetCanvasGroupAlpha(canvasGroup, 0f);
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
