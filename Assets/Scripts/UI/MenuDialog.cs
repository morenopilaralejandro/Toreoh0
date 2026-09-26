using UnityEngine;

public class MenuDialog : MonoBehaviour
{
    /*
    // TODO inherit menu
    [Header(UI References)]
    [SerializeField] private DialogBox dialogBox;
    [SerializeField] private DialogSpeakerPortraitUI speakerPortrait;
    [SerializeField] private DialogSpeakerNameUI speakerPortraitName;

    // Lifecycle
    protected override void Open() => Clear();
    protected override void Close() => Clear();

    public void Clear() 
    {
        dialogBox.Clear();
        speakerPortrait.Clear();
        speakerPortraitName.Clear();
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.Dialog.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.Dialog.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputDialog input)
    {
        if (input = InputDialog.Continue) OnButtonContinueClicked();
    }

    public void OnButtonContinueClicked() 
    {
        dialogBox.OnButtonContinueClicked;
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
    */
}
