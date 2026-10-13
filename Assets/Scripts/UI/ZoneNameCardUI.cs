using UnityEngine;
using TMPro;
using System.Collections;

public class ZoneNameCardUI : MonoBehaviour 
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_Text textName;
    [SerializeField] private float fadeDuration = 0.25f;
    [SerializeField] private float displayDuration = 1f;
    private Coroutine coroutine;

    
    // display
    private IEnumerator DisplayData(ZoneData zoneCurrent, string zoneCurrentName) 
    {
        if (canvasGroup.alpha > 0f)
            yield return UIUtils.FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0f, fadeDuration, null);

        textName.text = zoneCurrentName;
        yield return UIUtils.FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1f, fadeDuration, null);
        yield return new WaitForSeconds(displayDuration);
        yield return UIUtils.FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0f, fadeDuration, null);
        coroutine = null;
    }

    // events
    private void OnEnable() 
    {
        WorldEvents.OnZoneChanged += OnZoneChanged;
    }

    private void OnDisable() 
    {
        WorldEvents.OnZoneChanged -= OnZoneChanged;
    }

    private void OnZoneChanged(ZoneData zonePrevious, ZoneData zoneCurrent, string zoneCurrentName) 
    {
        if (zonePrevious == zoneCurrent) return;
        if (!zoneCurrent.HasDisplayName) return;
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(DisplayData(zoneCurrent, zoneCurrentName));
    }
}
