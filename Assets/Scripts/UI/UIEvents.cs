using UnityEngine;
using System;
using Aremoreno.Enums.UI;

public static class UIEvents 
{
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
}
