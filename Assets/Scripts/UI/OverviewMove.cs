using UnityEngine;
using System.Threading.Tasks;

public class OverviewMove : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private MoveUI moveUI;

    private async Task SetData(Move move) 
    {
        await moveUI.SetAsync(move);
        UIUtils.SetCanvasGroupAlpha(canvasGroup, true);
    }

    private void Clear() 
    {
        moveUI.Clear();
        UIUtils.SetCanvasGroupAlpha(canvasGroup, false);
    }

    private void OnEnable()
    {
        UIEvents.OnMoveOverviewUpdateRequested += OnMoveOverviewUpdateRequested;
    }

    private void OnDisable()
    {
        UIEvents.OnMoveOverviewUpdateRequested -= OnMoveOverviewUpdateRequested;
    }

    private async void OnMoveOverviewUpdateRequested(Move move) 
    {
        if (!canvasGroup.interactable) return;
        if (move == null)
            Clear();
        else
            await SetData(move);
    }
}
