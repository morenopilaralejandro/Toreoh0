using UnityEngine;
using System;
using Aremoreno.Enums.UI;

public class MenuComponentStateMachineConfirm : MonoBehaviour
{
    private MenuComponentStateMachine<MenuStateConfirm> stateMachine;
    private Action onConfirm;

    private void Awake()
    {
        stateMachine = new MenuComponentStateMachine<MenuStateConfirm>(MenuStateConfirm.Idle);
    }

    public void SetConfirmAction(Action onConfirm) 
    {
        this.onConfirm = onConfirm;
    }

    public void SetWaitingForConfirm() 
    {
        stateMachine.Set(MenuStateConfirm.WaitingForConfirm);
    }

    // Event
    private void OnEnable() 
    {
        UIEvents.OnDialogConfirmConfirmed += OnDialogConfirmConfirmed;
        UIEvents.OnDialogConfirmCanceled += OnDialogConfirmCanceled;
    }

    private void OnDisable()
    {
        UIEvents.OnDialogConfirmConfirmed -= OnDialogConfirmConfirmed;
        UIEvents.OnDialogConfirmCanceled -= OnDialogConfirmCanceled;
    }

    private void OnDialogConfirmConfirmed() 
    {
        if (!stateMachine.Is(MenuStateConfirm.WaitingForConfirm)) return;
        stateMachine.Set(MenuStateConfirm.Idle);
        onConfirm?.Invoke();
    }

    private void OnDialogConfirmCanceled() 
    {
        if (!stateMachine.Is(MenuStateConfirm.WaitingForConfirm)) return;
        stateMachine.Set(MenuStateConfirm.Idle);
    }
}
