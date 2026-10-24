using UnityEngine;

public class AutoSaveCardUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 0.25f;

    // events
    private void OnEnable()
    {
        PersistenceEvents.OnAutoSaveRequested += OnAutoSaveRequested;
        PersistenceEvents.OnGameSaveEnded += OnGameSaveEnded;
    }

    private void OnDisable()
    {
        PersistenceEvents.OnAutoSaveRequested -= OnAutoSaveRequested;
        PersistenceEvents.OnGameSaveEnded -= OnGameSaveEnded;
    }

    private void OnAutoSaveRequested() => UIUtils.FadeCanvasGroup(canvasGroup, 0f, 1f, fadeDuration, null);
    private void OnGameSaveEnded(SaveData saveData) => UIUtils.FadeCanvasGroup(canvasGroup, 1f, 0f, fadeDuration, null);
}
