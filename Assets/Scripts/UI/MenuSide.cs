using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.UI;

public class MenuSide : Menu
{
    //[Header("UI References")]
    //[SerializeField] private DialogBoxUI dialogBox;
    [SerializeField] private List<LocalizationReferenceStyleMapping> listMappingReferenceConfirmExit;
    private MenuComponentStateMachine<MenuStateBasic> stateMachine;

    // Lifecycle
    protected override void Awake() 
    {
        stateMachine = new MenuComponentStateMachine<MenuStateBasic>(MenuStateBasic.Idle);
        base.Awake();
    }

    // Input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() 
    {
        RequestClose();
    }

    public void OnButtonOpenClicked() 
    {
        OnMenuSideOpenRequested();
    }

    public void OnButtonBagClicked() 
    {
        UIEvents.RaiseSelectorItemStorageSlotBagOpenRequested(
            null, 
            new SelectorItemStorageSlotBagActionClickUse(),
            null);
    }

    public void OnButtonSaveClicked() 
    {
        WorldArgs.SetFromWorld();
        UIEvents.RaiseSelectorSaveSlotOpenRequested(
            new SelectorSaveSlotSource(), 
            new SelectorSaveSlotActionClickSave(),
            null);
    }

    public void OnButtonExitClicked() 
    {
        stateMachine.Set(MenuStateBasic.WaitingForConfirm);
        UIEvents.RaiseDialogConfirmOpenRequested(listMappingReferenceConfirmExit);
    }

    // Event
    protected override void OnEnable() 
    {
        base.OnEnable();
        UIEvents.OnMenuSideOpenRequested += OnMenuSideOpenRequested;
        UIEvents.OnDialogConfirmConfirmed += OnDialogConfirmConfirmed;
        UIEvents.OnDialogConfirmCanceled += OnDialogConfirmCanceled;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnMenuSideOpenRequested -= OnMenuSideOpenRequested;
        UIEvents.OnDialogConfirmConfirmed -= OnDialogConfirmConfirmed;
        UIEvents.OnDialogConfirmCanceled -= OnDialogConfirmCanceled;
    }

    private void OnMenuSideOpenRequested() => MenuManager.Instance.OpenMenu(this);

    private void OnDialogConfirmConfirmed() 
    {
        if (!stateMachine.Is(MenuStateBasic.WaitingForConfirm)) return;
        stateMachine.Set(MenuStateBasic.Idle);
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-MainMenu");
    }

    private void OnDialogConfirmCanceled() 
    {
        if (!stateMachine.Is(MenuStateBasic.WaitingForConfirm)) return;
        stateMachine.Set(MenuStateBasic.Idle);
    }
}
