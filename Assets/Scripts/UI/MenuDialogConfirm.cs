using UnityEngine;
using UnityEngine.Localization;
using System.Collections.Generic;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.UI;

public class MenuDialogConfirm : Menu
{
    [Header("UI References")]
    [SerializeField] private LocalizationComponentUIText textMessage;
    [SerializeField] private List<MenuDialogConfirmMessageMapping> messageMapping;
    private Dictionary<DialogConfrimMessageType, List<LocalizationReferenceStyleMapping>> dictMessage = new ();

    // Lifecycle
    protected override void Awake() 
    {
        BuildDict();
        base.Awake();
    }

    public override void OnOpened() 
    {
        base.OnOpened();
        UIEvents.RaiseDialogConfirmOpened(); 
    }

    private void BuildDict() 
    {
        dictMessage.Clear();
        foreach (var mapping in messageMapping) 
            dictMessage[mapping.DialogConfrimMessageType] = mapping.ListMappingReference;
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonCancelClicked();
    }

    public void OnButtonConfirmClicked() 
    {
        RequestClose();
        UIEvents.RaiseDialogConfirmConfirmed();
    }

    public void OnButtonCancelClicked() 
    {
        RequestClose();
        UIEvents.RaiseDialogConfirmCanceled();
    }

    // Event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnDialogConfirmOpenRequested += OnDialogConfirmOpenRequested;
        UIEvents.OnDialogConfirmOpenRequestedByMessageType += OnDialogConfirmOpenRequestedByMessageType;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnDialogConfirmOpenRequested -= OnDialogConfirmOpenRequested;
        UIEvents.OnDialogConfirmOpenRequestedByMessageType -= OnDialogConfirmOpenRequestedByMessageType;
    }

    private void OnDialogConfirmOpenRequested(List<LocalizationReferenceStyleMapping> listMappingReference) 
    {
        textMessage.SetData(listMappingReference);
        MenuManager.Instance.OpenMenu(this);
    }

    private void OnDialogConfirmOpenRequestedByMessageType(DialogConfrimMessageType messageType) 
    {
        textMessage.SetData(dictMessage[messageType]);
        MenuManager.Instance.OpenMenu(this);
    }
}
