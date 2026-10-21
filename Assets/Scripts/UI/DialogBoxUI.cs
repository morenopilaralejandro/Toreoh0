using UnityEngine;
using UnityEngine.UI;

public class DialogBoxUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TypeWriterUI typeWriter;
    [SerializeField] private CanvasGroup continueIndicator;

    public void Clear() 
    {
        typeWriter.Clear();
        UIUtils.SetCanvasGroupVisible(continueIndicator, false);
    }

    //Input
    public void OnButtonContinueClicked() 
    {
        if (typeWriter.IsTyping)
            typeWriter.RequestSkip();
        else
            DialogEvents.RaiseContinueRequested();
    }

    // Events
    private void OnEnable() 
    {
        DialogEvents.OnLineReady += OnLineReady;
        typeWriter.OnTypeWriterEnded += OnTypeWriterEnded;
    }

    private void OnDisable() 
    {
        DialogEvents.OnLineReady -= OnLineReady;
        typeWriter.OnTypeWriterEnded -= OnTypeWriterEnded;
    }

    private void OnLineReady(DialogSerializableLine line, Speaker speaker) 
    {
        UIUtils.SetCanvasGroupVisible(continueIndicator, false);
        typeWriter.StartTypeWriter(line.TextResolved); 
    }

    private void OnTypeWriterEnded() 
    {
        UIUtils.SetCanvasGroupVisible(continueIndicator, true);
    }
}
