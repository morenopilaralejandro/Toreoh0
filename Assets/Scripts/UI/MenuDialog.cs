using UnityEngine;
using Aremoreno.Enums.Input;

public class MenuDialog : Menu
{
    [Header("UI References")]
    [SerializeField] private DialogBoxUI dialogBox;
    [SerializeField] private DialogSpeakerPortraitUI speakerPortrait;
    [SerializeField] private DialogSpeakerNameUI speakerPortraitName;

    // Lifecycle
    public override void OnOpened() => Clear();
    public override void OnClosed() => Clear();

    public void Clear() 
    {
        dialogBox.Clear();
        speakerPortrait.Clear();
        speakerPortraitName.Clear();
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapDialog.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapDialog.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputDialog input)
    {
        if (input == InputDialog.Continue) OnButtonContinueClicked();
    }

    public void OnButtonContinueClicked() 
    {
        dialogBox.OnButtonContinueClicked();
    }

    // Event
    protected override void OnEnable() 
    {
        base.OnEnable();
        DialogEvents.OnDialogStarted += OnDialogStarted;
        DialogEvents.OnDialogEnded += OnDialogEnded;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        DialogEvents.OnDialogStarted -= OnDialogStarted;
        DialogEvents.OnDialogEnded -= OnDialogEnded;
    }

    private void OnDialogStarted() => MenuManager.Instance.OpenMenu(this);
    private void OnDialogEnded() => RequestClose();
}
