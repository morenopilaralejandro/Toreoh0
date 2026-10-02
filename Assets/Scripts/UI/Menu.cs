using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public abstract class Menu : MonoBehaviour, IMenuClosable
{
    // fields
    [Header("Generic")]

    [SerializeField] protected List<CanvasGroup> canvasGroupList;
    [SerializeField] protected List<GameObject> gameObjectList;
    [SerializeField] protected Selectable defaultSelectable;
    [SerializeField] protected bool hasMemory = true;
    [SerializeField] protected bool isCloseAllPreviousOnBack = false;

    [Header("Hidden")]
    [SerializeField] protected bool isHiddenOnAwake = true;
    [SerializeField] protected bool isHiddenWhenNotInterable = false;
    [SerializeField] protected bool isDeactivatedOnHide = false; // gameObject.SetActive(false)
    [SerializeField] protected bool isHiddenWhenCovered = false;
    [SerializeField] protected bool isDimmedWhenCovered = false;
    [SerializeField, Range(0f, 1f)] protected float dimmedAlpha = 0.5f;

    [Header("Audio")]
    [SerializeField] protected string sfxOpen  = "sfx-menu_open";
    [SerializeField] protected string sfxClose = "sfx-menu_close";

    protected MenuManager menuManager;
    protected InputManager inputManager;
    protected AudioManager audioManager;

    protected GameObject lastSelected;
    protected bool wasInteractable;
    protected bool isRestoringFocus;

    public bool IsCloseAllPreviousOnBack => isCloseAllPreviousOnBack;
    public GameObject LastSelected => lastSelected;
    public MenuManager MenuManager => menuManager;
    public InputManager InputManager => inputManager;

    // lifecycle
    protected virtual void Awake()
    {
        if(isHiddenOnAwake) HideImmediately();
    }

    protected virtual void Start()
    {
        menuManager = MenuManager.Instance;
        inputManager = InputManager.Instance;
        audioManager = AudioManager.Instance;
    }

    protected virtual void OnEnable() 
    {
        UIEvents.OnSelectableSelected += OnSelectableSelected;
    }

    protected virtual void OnDisable() 
    {
        UIEvents.OnSelectableSelected -= OnSelectableSelected;
        isRestoringFocus = false;
        if (!wasInteractable) return;
        OnLostInput();
        wasInteractable = false;
    }

    // visibility
    public virtual void Show() 
    {
        if (isDeactivatedOnHide)
            SetActive(true);
        else
            SetVisible(true);
        SetDefaultFocus();
    }

    public virtual void Hide()
    {
        if (isDeactivatedOnHide)
            SetActive(false);
        else
            SetVisible(false);
    }

    protected void HideImmediately() 
    {
        SetInteractable(false);
        Hide();
    }

    public void SetVisible(bool isVisible) 
    {
        foreach (var canvasGroup in canvasGroupList)
            canvasGroup.alpha = isVisible ? 1f : 0f;
    }

    public void SetAlpha(float alpha) 
    {
        foreach (var canvasGroup in canvasGroupList)
            canvasGroup.alpha = alpha;
    }

    public void SetActive(bool isActive) 
    {
        foreach (var go in gameObjectList)
            go.SetActive(isActive);
    }


    // interactability
    public virtual void SetInteractable(bool isInteractable)
    {
        foreach (var canvasGroup in canvasGroupList) 
        {
            canvasGroup.interactable = isInteractable;
            canvasGroup.blocksRaycasts = isInteractable;
        }

        if (isHiddenWhenNotInterable) SetVisible(isInteractable);
        if (isInteractable && !wasInteractable) OnGainedInput();
        else if (!isInteractable && wasInteractable) OnLostInput();
        wasInteractable = isInteractable;
        if (isInteractable) SetDefaultFocus();
    }

    public virtual bool IsInteractable() => canvasGroupList[0].interactable;
    
    // input
    protected virtual void OnGainedInput() { }
    protected virtual void OnLostInput() { }
    
    // menu manager
    public virtual void OnOpened() 
    {
        if (!string.IsNullOrEmpty(sfxOpen))
            _ = audioManager.SfxUI.Play(sfxOpen);
    }

    public virtual void OnClosed() 
    {
        if (!string.IsNullOrEmpty(sfxOpen))
            _ = audioManager.SfxUI.Play(sfxClose);
    }

    public virtual void OnCovered() 
    {
        if (isHiddenWhenCovered) SetVisible(false);
        else if (isDimmedWhenCovered) SetAlpha(dimmedAlpha);
    }

    public virtual void OnRevealed() 
    {
        if (isHiddenWhenCovered || isDimmedWhenCovered) SetAlpha(1f);
    }

    // memory
    public void SetLastSelected(GameObject obj) => lastSelected = obj;
    public void SetDefaultSelectable(Selectable selectable, bool focusImmediately = true)
    {
        defaultSelectable = selectable;
        if(!inputManager.ControlSchemeTracker.ShouldAutoFocus) return;
        if (focusImmediately && selectable != null)
        {
            EventSystem.current.SetSelectedGameObject(selectable.gameObject);
            lastSelected = selectable.gameObject;
        }
    }

    protected virtual void SetDefaultFocus() 
    {
        if(!inputManager.ControlSchemeTracker.ShouldAutoFocus) return;
        isRestoringFocus = true;
        if (hasMemory && lastSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelected);
            isRestoringFocus = false;
            return;
        }
        if (defaultSelectable == null || EventSystem.current.currentSelectedGameObject == defaultSelectable.gameObject) 
        {
            isRestoringFocus = false;
            return;
        }
        EventSystem.current.SetSelectedGameObject(defaultSelectable.gameObject);
        isRestoringFocus = false;
    }

    protected virtual void OnSelectableSelected(GameObject go) 
    {
        if (!IsInteractable()) return;
        if (go == null) return;
        if (!go.transform.IsChildOf(transform)) return;
        lastSelected = go;
        if (isRestoringFocus) return;
        // TODO extra logic
    }

    // interface IMenuClosable
    public void RequestClose() => menuManager.RequestClose(this);
}
