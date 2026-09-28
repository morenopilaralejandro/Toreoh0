public abstract class Menu : MonoBehaviour, IMenuClosable
{
    // fields
    [Header("Generic")]
    [SerializeField] protected CanvasGroup canvasGroup;
    [SerializeField] protected Selectable defaultSelectable;
    [SerializeField] protected bool hasMemory = true;
    [SerializeField] protected bool isCloseAllPreviousOnBack = false;

    [Header("Hidden")]
    [SerializeField] protected bool isHiddenOnAwake = true;
    [SerializeField] protected bool isHiddenWhenNotInterable = false;
    [SerializeField] protected bool isDeactivatedOnHide = false; // gameObject.SetActive(false)
    [SerializeField] protected bool isHiddenWhenCovered = false
    [SerializeField] protected bool isDimmedWhenCovered = false;
    [SerializeField, Range(0f, 1f)] protected float dimmedAlpha = 0.5;

    [Header("Audio")]
    [SerializeField] protected string sfxOpen  = "sfx-menu_open";
    [SerializeField] protected string sfxClose = "sfx-menu_close";

    protected MenuManager menuManager;
    protected InputManager inputManager;

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
            gameObject.SetActive(true);
        else
            canvasGroup.alpha = 1f;
        SetDefaultFocus();
    }

    public virtual void Hide()
    {
        if (isDeactivatedOnHide)
            gameObject.SetActive(false);
        else
            canvasGroup.alpha = 0f;
    }

    public void SetVisible(bool isVisible) 
    {
        canvasGroup.alpha = isVisible ? 1f : 0f;
    }

    protected void HideImmediately() 
    {
        SetInteractable(false);
        Hide();
    }

    // interactability
    public virtual void SetInteractable(bool isInteractable)
    {
        canvasGroup.interactable = isInteractable;
        canvasGroup.blocksRaycasts = isInteractable;
        if (isHiddenWhenNotInterable) canvasGroup.alpha = isInteractable ? 1f : 0f;
        if (isInteractable && !wasInteractable) OnGainedInput();
        else if (!isInteractable && wasInteractable) OnLostInput();
        wasInteractable = isInteractable;
        if (isInteractable) SetDefaultFocus;
    }

    public virtual bool IsInteractable() => canvasGroup.interactable;
    
    // input
    protected virtual void OnGainedInput() { }
    protected virtual void OnLostInput() { }
    
    // menu manager
    public virtual void OnOpened() 
    {
        if (!string.IsNullOrEmpty(sfxOpen))
            AudioManager.Instance.SfxUI.Play(sfxOpen);
    }

    public virtual void OnClosed() 
    {
        if (!string.IsNullOrEmpty(sfxOpen))
            AudioManager.Instance.SfxUI.Play(sfxClose);
    }

    public virtual void OnCovered() 
    {
        if (isHiddenWhenCovered) SetVisible(false);
        else if (isDimmedWhenCovered) canvasGroup.alpha = dimmedAlpha;
    }

    public virtual void OnRevealed() 
    {
        if (isHiddenWhenCovered || isDimmedWhenCovered) canvasGroup.alpha = 1f;
    }

    // memory
    public void SetLastSelected(GameObject obj) => lastSelected = obj;
    public void SetDefaultSelectable(Selectable selectable, bool focusImmediately = true)
    {
        defaultSelectable = selectable;
        if(!inputManager.ShouldAutoFocus) return;
        if (focusImmediately && selectable != null)
        {
            EventSystem.current.SetSelectedGameObject(selectable.gameObject);
            lastSelected = selectable.gameObject;
        }
    }

    protected virtual void SetDefaultFocus() 
    {
        if(!inputManager.ShouldAutoFocus) return;
        isRestoringFocus = true;
        if (hasMemory && lastSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelected);
            isRestoringFocus = false;
            return;
        }
        if (defaultSelectable == null || EventSystem.current.curretSeletedGameObject == defaultSelectable.gameObject) 
        {
            isRestoringFocus = false;
            return;
        }
        EventSystem.current.SetSelectedGameObject(defaultSelectable.gameObject);
        isRestoringFocus = false;
    }

    protected virtual void OnSelectableSelected(GameObject go) 
    {
        if (!IsInteractable() return);
        if (go == null) return;
        if (!go.transform.IsChildOf(transform)) return;
        lastSelected = go;
        if (isRestoringFocus) return;
        // TODO extra logic
    }

    // interface IMenuClosable
    public void RequestClose() => menuManager.RequestClose(this);
}
