public class TypeWritterUI : MoneBehaviour 
{
    [SerializeField] TMP_Text text;
    [SerializeField] private AudioClip writterSfxClip;
    [SerializeField] private float writterSfxInterval = 2f;
    [SerializeField] private float writterPauseDurationDefault = 0.03f;
    [SerializeField] private float writterPauseDurationSkip = 0.005f;

    private Coroutine typeWritterCoroutine;
    private bool isTyping;
    private bool isSkipRequested;
    public event Action OnTypeWritterEnded;

    public IsTyping => isTyping;

    // TMP_Text TextMeshProUGUI

    public void RequestSkip() => isSkipRequested = true;

    private IEnumerator TypeWritterEffect(string stringValue)
    {
        isTyping = true;
        isSkipRequested = false;

        text.text = stringValue;
        text.maxVisibleCharacters = 0;

        int totalCharacters = string.Length;
        int visibleCount = 0;
        int sfxCounter = 0;
        while (visibleCount < totalCharacters)
        {
            if (isSkipRequested)
            {
                text.maxVisibleCharacters = totalCharacters;
                break;
            }
            visibleCount++;
            text.maxVisibleCharacters = visibleCount;
            sfxCounter++;
            if (sfxCounter >= writterSfxInterval) 
            {
                AudioManager.Instance.Sfx.Play(writterSfxClip);
                sfxCounter = 0;
            }
            float pauseDuration = isSkipRequested ? writterPauseDurationSkip : writterPauseDurationDefault;
            yield return new WaitForSeconds(pauseDuration);
        }
        isTyping = false;
        OnTypeWritterEnded.Invoke();
        // event to set continue indicator visible and raise display text complete
    }

    public void StartTypeWritter(string stringValue) 
    {
        Clear();
        typeWritterCoroutine = StartCoroutine(TypeWritterEffect(stringValue));
    }

    public void StopTypeWritter() 
    {
        if (typeWritterCoroutine == null) return;
        StopCoroutine(typeWritterCoroutine);
        typeWritterCoroutine = null;
    }

    public void Clear() 
    {
        StopTypeWritter();
        text.text = string.Empty;
        text.maxVisibleCharacters = 0;
        isTyping = false;
        isSkipRequested = false;
    }
}
