public static void UIUtils
{
    public static void SetCancasGroupVisible(CanvasGroup canvasGroup, bool isVisible)
    {
        canvasGroup.alpha = isVisible ? 1f : 0f;
        canvasGroup.interactable = isVisible;
        canvasGroup.blocksRaycast = isVisible;
    }

    public static void SetCancasGroupInteractable(CanvasGroup canvasGroup, bool isInteractable)
    {
        canvasGroup.interactable = isInteractable;
        canvasGroup.blocksRaycast = isInteractable;
    }

    public static IEnumerator FadeCanvasGroup(
        CanvasGroup canvasGroup
        float fromValue,
        float toValue,
        float duration,
        Action onComplete = null)
    {
        float elapsed = 0f;
        canvasGroup.alpha = fromValue;
        while (elapsed < duration) 
        {
            elapsed += Time.delpaTime;
            canvasGroup.alpha = Mathf.Lerp(fromValue, toValue, elapsed / duration);
            yield return null;
        }
        canvasGroup.alpha = toValue;
        onComplete?.Invoke();
    }

    /*
    fadeCoroutine = StartCoroutine(UIUtils.FadeCanvasGroup(
        canvasGroup, 
        canvasGroup.alpha, 
        0f, 
        fadeSpeed,
        () => 
        {
            // execute code after it is complete
        }));
    */
}
