using UnityEngine;
using UnityEngine.UI;

public class DialogBoxUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TypeWritterUI typeWritter;
    [SerializeField] private CanvasGroup continueIndicator;

    public void Clear() 
    {
        typeWritter.Clear();
        UIUtils.SetCanvasGroupVisible(continueIndicator, false);
    }

    //Input
    public void OnButtonContinueClicked() 
    {
        if (typeWritter.IsTyping)
            typeWritter.RequestSkip();
        else
            DialogEvents.RaiseContinueRequested();
    }

    // Events
    private void OnEnable() 
    {
        DialogEvents.OnLineReady += OnLineReady;
        typeWritter.OnTypeWritterEnded += OnTypeWritterEnded;
    }

    private void OnDisable() 
    {
        DialogEvents.OnLineReady -= OnLineReady;
        typeWritter.OnTypeWritterEnded -= OnTypeWritterEnded;
    }

    private void OnLineReady(DialogSerializableLine line, Speaker speaker) 
    {
        UIUtils.SetCanvasGroupVisible(continueIndicator, false);
        typeWritter.StartTypeWritter(line.TextResolved); 
    }

    private void OnTypeWritterEnded() 
    {
        UIUtils.SetCanvasGroupVisible(continueIndicator, true);
    }
}
