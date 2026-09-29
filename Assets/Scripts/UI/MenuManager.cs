using UnityEngine;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // fields
    private readonly Stack<Menu> stackOpened = new();
    private readonly HashSet<Menu> hashSetPendingClose = new();

    // open
    public void OpenMenu(Menu menu) 
    {
        if (menu == null) return;
        if (stackOpened.Contains(menu)) return;
        if (stackOpened.Count > 0) CoverMenuInternal(stackOpened.Peek());
        OpenMenuInternal(menu);
    }

    public void ReplaceMenu(Menu menu) 
    {
        if (menu == null) return;
        if (stackOpened.Contains(menu)) return;
        if (stackOpened.Count > 0) CloseMenuInternal(stackOpened.Pop());
        OpenMenuInternal(menu);
    }

    // close
    public void RequestClose(Menu menu)
    {
        if (menu == null) return;
        if(!stackOpened.Contains(menu)) return;
        if (stackOpened.Peek() == menu)
            CloseMenuTop();
        else
            hashSetPendingClose.Add(menu);
    }

    public void CloseMenuTop() 
    {
        if(stackOpened.Count == 0) return;
        Menu top = stackOpened.Pop();
        CloseMenuInternal(top);

        if (top.IsCloseAllPreviousOnBack) 
        {
            CloseMenuAll();
            return;
        }

        while (stackOpened.Count > 0) 
        {
            var next = stackOpened.Peek();
            if (hashSetPendingClose.Contains(next))
            {
                stackOpened.Pop();
                CloseMenuInternal(next);
                continue;
            }
            RevealMenuInternal(next);
            return;
        }

        UIEvents.RaiseMenuClosedAll();
    }

    public void CloseMenuAll() 
    {
        while (stackOpened.Count > 0)
            CloseMenuInternal(stackOpened.Pop());
        hashSetPendingClose.Clear();
        UIEvents.RaiseMenuClosedAll();
    }

    // helper
    private void OpenMenuInternal(Menu menu) 
    {
        stackOpened.Push(menu);
        menu.OnOpened();
        menu.Show();
        menu.SetInteractable(true);
        UIEvents.RaiseMenuOpened(menu);
    }

    private void CloseMenuInternal(Menu menu) 
    {
        hashSetPendingClose.Remove(menu);
        menu.SetInteractable(menu);
        menu.Hide();
        menu.OnClosed();
        UIEvents.RaiseMenuClosed(menu);
    }

    private void CoverMenuInternal(Menu menu) 
    {
        menu.SetInteractable(false);
        menu.OnCovered();
    }

    private void RevealMenuInternal(Menu menu) 
    {
        menu.OnRevealed();
        menu.SetInteractable(true);
    }

    // api
    public int Count => stackOpened.Count;
    public Menu CurrentMenu => stackOpened.Count > 0 ? stackOpened.Peek() : null;
    public bool IsMenuOnTop(Menu menu) => stackOpened.Count > 0 && stackOpened.Peek() == menu;
    public bool IsMenuOpened(Menu menu) => stackOpened.Contains(menu);
}
