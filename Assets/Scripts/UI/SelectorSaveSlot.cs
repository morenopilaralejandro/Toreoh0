using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Aremoreno.Enums.Input;

public class SelectorSaveSlot : Selector<SaveSlot, SelectorSaveSlotListItem>
{
    // fields
    [Header("UI")]
    [SerializeField] private CanvasGroup canvasGroupPanelSaving;
    [SerializeField] private CanvasGroup canvasGroupButtonNew;
    [SerializeField] private LocalizationComponentUIText textLocalizationComponent;
    [SerializeField] private List<LocalizationReferenceStyleMapping> localizationMappingSave;
    [SerializeField] private List<LocalizationReferenceStyleMapping> localizationMappingLoad;

    // override
    public override void OnOpened() 
    {
        UIEvents.RaiseSaveDataOverviewUpdateRequested(null);
        switch (actionClick)
        {
            case SelectorSaveSlotActionClickSave save:
                UIUtils.SetCanvasGroupVisible(canvasGroupButtonNew, false);
                textLocalizationComponent.SetData(localizationMappingSave);
                break;
            case SelectorSaveSlotActionClickLoad load:
                UIUtils.SetCanvasGroupVisible(canvasGroupButtonNew, true);
                textLocalizationComponent.SetData(localizationMappingLoad);
                break;             
        }
    }

    // input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        if (input == InputNavigation.Back) OnButtonBackClicked();
    }

    public void OnButtonBackClicked() => RequestClose();

    public void OnButtonNewGameClicked() 
    {
        PersistenceEvents.RaiseNewGameStarted();
        RequestClose();
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-World");
    }

    // event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnSelectorSaveSlotOpenRequested += OnSelectorSaveSlotOpenRequested;
        UIEvents.OnSelectorSaveSlotCloseRequested += OnSelectorSaveSlotCloseRequested;
        UIEvents.OnDialogConfirmConfirmed += OnDialogConfirmConfirmed;
        PersistenceEvents.OnGameSaveStarted += OnGameSaveStarted;
        PersistenceEvents.OnGameSaveEnded += OnGameSaveEnded;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UIEvents.OnSelectorSaveSlotOpenRequested -= OnSelectorSaveSlotOpenRequested;
        UIEvents.OnSelectorSaveSlotCloseRequested -= OnSelectorSaveSlotCloseRequested;
        UIEvents.OnDialogConfirmConfirmed -= OnDialogConfirmConfirmed;
        PersistenceEvents.OnGameSaveStarted -= OnGameSaveStarted;
        PersistenceEvents.OnGameSaveEnded -= OnGameSaveEnded;
    }

    private void OnSelectorSaveSlotOpenRequested(
        ISelectorSource<SaveSlot> source,
        ISelectorActionClick<SaveSlot> actionClick,
        ISelectorFilter<SaveSlot> filter)
    {
        Open(source, actionClick, filter);
    }

    private void OnSelectorSaveSlotCloseRequested() 
    {
        RequestClose();
    }

    private void OnDialogConfirmConfirmed() 
    {
        if (!menuManager.IsMenuOpened(this)) return;
        lastSelectedElement.Data.Saver.SaveGame();
    }

    private void OnGameSaveStarted() 
    {
        if (!menuManager.IsMenuOpened(this)) return;
        UIUtils.SetCanvasGroupVisible(canvasGroupPanelSaving, true);
    }

    private void OnGameSaveEnded(SaveData saveData) 
    {
        if (!menuManager.IsMenuOpened(this)) return;
        UIUtils.SetCanvasGroupVisible(canvasGroupPanelSaving, false);
        RequestClose();
    }
}
