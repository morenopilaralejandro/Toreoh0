using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class SelectorItemStorageSlotBag : Selector<ItemStorageSlot, SelectorItemStorageSlotBagListItem>
{
    // fields
    //[Header("Visuals")]
    //[SerializeField] private int intValue;

    // override

    // input
    protected override void OnGainedInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown += OnButtonDown;
    protected override void OnLostInput() => InputManager.Instance.MapNavigation.Tracker.OnButtonDown -= OnButtonDown;

    private void OnButtonDown(InputNavigation input)
    {
        switch(input) 
        {
            case InputNavigation.Back:
                OnButtonBackClicked();
                break;
            case InputNavigation.ShortcutBagNext:
                break;
            case InputNavigation.ShortcutBagPrevious:
                break;
        }
    }

    public void OnButtonBackClicked()
    {
        RequestClose();
    }

    // event
    protected override void OnEnable()
    {
        base.OnEnable();
        UIEvents.OnSelectorItemStorageSlogBagOpenRequested += OnSelectorItemStorageSlogBagOpenRequested;
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
        UIEvents.OnSelectorItemStorageSlogBagOpenRequested -= OnSelectorItemStorageSlogBagOpenRequested;
    }

    private void OnChoicesReady(
        ISelectorSource<ItemStorageSlot> source, 
        ISelectorActionClick<ItemStorageSlot> actionClick, 
        ISelectorFilter<ItemStorageSlot> filter) 
    {
        Open(source, actionClick, filter);
    }
}
