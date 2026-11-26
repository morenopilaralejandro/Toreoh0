using UnityEngine;
using System;
using System.Collections.Generic;
using Aremoreno.Enums.Item;
using Aremoreno.Enums.Persistence;
using Aremoreno.Enums.UI;

public static class UIEvents 
{
    // Battle
    public static event Action<CharacterEntityBattle> OnBattleParticipantUpdateRequeted;
    public static void RaiseBattleParticipantUpdateRequeted(CharacterEntityBattle entity) 
        => OnBattleParticipantUpdateRequeted?.Invoke(entity);

    public static event Action<CharacterEntityBattle> OnCharacterHpDecreased;
    public static void RaiseCharacterHpDecreased(CharacterEntityBattle entity)
        => OnCharacterHpDecreased?.Invoke(entity);

    public static event Action<CharacterEntityBattle> OnCharacterMpDecreased;
    public static void RaiseCharacterMpDecreased(CharacterEntityBattle entity)
        => OnCharacterMpDecreased?.Invoke(entity);

    public static event Action<string, string> OnCutsceneBattleStarted;
    public static void RaiseCutsceneBattleStarted(string name, string addressEvolution)
        => OnCutsceneBattleStarted?.Invoke(name, addressEvolution);

    public static event Action OnCutsceneBattleEnded;
    public static void RaiseCutsceneBattleEnded()
        => OnCutsceneBattleEnded?.Invoke();

    // memory
    public static event Action<GameObject> OnSelectableSelected;
    public static void RaiseSelectableSelected(GameObject go) 
        => OnSelectableSelected?.Invoke(go);

    // menu
    public static event Action<Menu> OnMenuOpened;
    public static void RaiseMenuOpened(Menu menu)
        => OnMenuOpened?.Invoke(menu);

    public static event Action<Menu> OnMenuClosed;
    public static void RaiseMenuClosed(Menu menu)
        => OnMenuClosed?.Invoke(menu);

    public static event Action OnMenuClosedAll;
    public static void RaiseMenuClosedAll()
        => OnMenuClosedAll?.Invoke();

    // menu open requested
    public static event Action OnMenuTestOpenRequested;
    public static void RaiseMenuTestOpenRequested()
        => OnMenuTestOpenRequested?.Invoke();

    public static event Action OnMenuSideOpenRequested;
    public static void RaiseMenuSideOpenRequested()
        => OnMenuSideOpenRequested?.Invoke();

    public static event Action<AmountPickerMode, Item, int, int, int, CurrencyType> OnMenuAmountPickerItemOpenRequested;
    public static void RaiseMenuAmountPickerItemOpenRequested(AmountPickerMode amountPickerMode, Item item, int countCurrent, int countMin, int countMax, CurrencyType currencyType)
        => OnMenuAmountPickerItemOpenRequested?.Invoke(amountPickerMode, item, countCurrent, countMin, countMax, currencyType);

    public static event Action OnMenuBattleCommandOpenRequested;
    public static void RaiseMenuBattleCommandOpenRequested()
        => OnMenuBattleCommandOpenRequested?.Invoke();

    public static event Action OnMenuBattleCommandCloseRequested;
    public static void RaiseMenuBattleCommandCloseRequested()
        => OnMenuBattleCommandCloseRequested?.Invoke();

    public static event Action<CharacterEntityBattle> OnMenuBattleCommandInitializeRequested;
    public static void RaiseMenuBattleCommandInitializeRequested(CharacterEntityBattle characterEntityBattle)
        => OnMenuBattleCommandInitializeRequested?.Invoke(characterEntityBattle);

    // selector open requested
    public static event Action<
        ISelectorSource<ItemStorageSlot>, 
        ISelectorActionClick<ItemStorageSlot>, 
        ISelectorFilter<ItemStorageSlot>
    > OnSelectorItemStorageSlotBagOpenRequested;
    public static void RaiseSelectorItemStorageSlotBagOpenRequested(
        ISelectorSource<ItemStorageSlot> source, 
        ISelectorActionClick<ItemStorageSlot> actionClick, 
        ISelectorFilter<ItemStorageSlot> filter)
        => OnSelectorItemStorageSlotBagOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action<
        ISelectorSource<Item>, 
        ISelectorActionClick<Item>, 
        ISelectorFilter<Item>
    > OnSelectorItemShopOpenRequested;
    public static void RaiseSelectorItemShopOpenRequested(
        ISelectorSource<Item> source, 
        ISelectorActionClick<Item> actionClick, 
        ISelectorFilter<Item> filter)
        => OnSelectorItemShopOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action<
        ISelectorSource<SaveSlot>, 
        ISelectorActionClick<SaveSlot>, 
        ISelectorFilter<SaveSlot>
    > OnSelectorSaveSlotOpenRequested;
    public static void RaiseSelectorSaveSlotOpenRequested(
        ISelectorSource<SaveSlot> source, 
        ISelectorActionClick<SaveSlot> actionClick, 
        ISelectorFilter<SaveSlot> filter)
        => OnSelectorSaveSlotOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action OnSelectorSaveSlotCloseRequested;
    public static void RaiseSelectorSaveSlotCloseRequested()
        => OnSelectorSaveSlotCloseRequested?.Invoke();

    public static event Action<
        ISelectorSource<Character>, 
        ISelectorActionClick<Character>, 
        ISelectorFilter<Character>
    > OnSelectorCharacterOpenRequested;
    public static void RaiseSelectorCharacterOpenRequested(
        ISelectorSource<Character> source, 
        ISelectorActionClick<Character> actionClick, 
        ISelectorFilter<Character> filter)
        => OnSelectorCharacterOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action<
        ISelectorSource<Move>, 
        ISelectorActionClick<Move>, 
        ISelectorFilter<Move>
    > OnSelectorMoveOpenRequested;
    public static void RaiseSelectorMoveOpenRequested(
        ISelectorSource<Move> source, 
        ISelectorActionClick<Move> actionClick, 
        ISelectorFilter<Move> filter)
        => OnSelectorMoveOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action<
        ISelectorSource<Wing>, 
        ISelectorActionClick<Wing>, 
        ISelectorFilter<Wing>
    > OnSelectorWingOpenRequested;
    public static void RaiseSelectorWingOpenRequested(
        ISelectorSource<Wing> source, 
        ISelectorActionClick<Wing> actionClick, 
        ISelectorFilter<Wing> filter)
        => OnSelectorWingOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action<
        ISelectorSource<Armor>, 
        ISelectorActionClick<Armor>, 
        ISelectorFilter<Armor>
    > OnSelectorArmorOpenRequested;
    public static void RaiseSelectorArmorOpenRequested(
        ISelectorSource<Armor> source, 
        ISelectorActionClick<Armor> actionClick, 
        ISelectorFilter<Armor> filter)
        => OnSelectorArmorOpenRequested?
            .Invoke(source, actionClick, filter);

    public static event Action<
        ISelectorSource<Weapon>, 
        ISelectorActionClick<Weapon>, 
        ISelectorFilter<Weapon>
    > OnSelectorWeaponOpenRequested;
    public static void RaiseSelectorWeaponOpenRequested(
        ISelectorSource<Weapon> source, 
        ISelectorActionClick<Weapon> actionClick, 
        ISelectorFilter<Weapon> filter)
        => OnSelectorWeaponOpenRequested?
            .Invoke(source, actionClick, filter);

    // overview
    public static event Action<Item> OnItemOverviewUpdateRequested;
    public static void RaiseItemOverviewUpdateRequested(Item item)
        => OnItemOverviewUpdateRequested?.Invoke(item);

    public static event Action<SaveData> OnSaveDataOverviewUpdateRequested;
    public static void RaiseSaveDataOverviewUpdateRequested(SaveData saveData)
        => OnSaveDataOverviewUpdateRequested?.Invoke(saveData);

    public static event Action<Move> OnMoveOverviewUpdateRequested;
    public static void RaiseMoveOverviewUpdateRequested(Move move)
        => OnMoveOverviewUpdateRequested?.Invoke(move);

    // confirm dialog
    public static event Action<List<LocalizationReferenceStyleMapping>> OnDialogConfirmOpenRequested;
    public static void RaiseDialogConfirmOpenRequested(List<LocalizationReferenceStyleMapping> listMappingReference)
        => OnDialogConfirmOpenRequested?.Invoke(listMappingReference);

    public static event Action<DialogConfrimMessageType> OnDialogConfirmOpenRequestedByMessageType;
    public static void RaiseDialogConfirmOpenRequestedByMessageType(DialogConfrimMessageType messageType)
        => OnDialogConfirmOpenRequestedByMessageType?.Invoke(messageType);

    public static event Action OnDialogConfirmOpened;
    public static void RaiseDialogConfirmOpened()
        => OnDialogConfirmOpened?.Invoke();

    public static event Action OnDialogConfirmConfirmed;
    public static void RaiseDialogConfirmConfirmed()
        => OnDialogConfirmConfirmed?.Invoke();

    public static event Action OnDialogConfirmCanceled;
    public static void RaiseDialogConfirmCanceled()
        => OnDialogConfirmCanceled?.Invoke();

    public static event Action<object> OnSelectorListItemSelectionConfirmed;
    public static void RaiseSelectorListItemSelectionConfirmed(object listItem)
        => OnSelectorListItemSelectionConfirmed?.Invoke(listItem);
}
