public abstract class Selector<TData, TListItem> : Menu, IMenuClosable where TListItem : SelectorListItem<TData>
{
    // fields
    listItemPrefab
    listItemContiner
    poolDefaultCapacity

    autoScroll
    scrollRect

    [Header("Selector")]
    [SerializeField] protected Button buttonClose;
    [SerializeField] protected bool isCloseOnSelect = false;

    protected ISelectorSource <TData> source;
    protected ISelectorActionClick <TData> actionClick;
    protected ISelectorFilter <TData> filter;

    pool

    // override
    protected override Start() 
    {
        // prewarm / create pool
    }

    public override Show()
    {
        base.Show();
        Populate
        activate scroll
    }

    public override Hide() 
    {
        return all to pool
        deactivate scroll
        base.Hide;
    }

    public override SetInteractable(bool isInteractable) 
    {
        base.SetInteractable(interactable);
        activate or deactivate scroll
    }

    // selector
    public void Open(ISelectorSource <TData> source, ISelectorActionClick <TData> actionClick, ISelectorFilter <TData> filter = null)
    {
        this.source = source;
        this.actionClick = actionClick;
        this.filter = filter;

        base.menuManager.OpenMenu(this);
    }

    public void SetSource(ISelectorSource<TData> source) => this.source = source;

    public void ApplyFilter(ISelectorFilter<TData> filter) 
    {
        this.filter = filter;
        Refresh();
    }

    public void Refresh() => Populate();

    protected virtual Populate() 
    {

    }

    // element

    public void FocusElement(int index, bool isFallbackToButtonClose = true) 
    {
        if ((index < 0 || pool.CountActive == 0) && isFallbackToButtonClose)
        {
            if (buttonClose != null) SetDefaultSelectable(buttonClose);
            return;
        }

        index = Mathf.Clamp(index, 0, pool.CountActive - 1); // fallback to first element
        SetDefaultSelectable(pool.ActiveElements[index].Button)
    }

    public int GetSelectedIndex()
    {
        var currentSelected = EventSystem.current.curretSeletedGameObject;
        if (currentSelected == null) return  -1;
        var element = currentSelected.GetComponent<TListItem>();
        if (element == null) return -1;
        return pool.ActiveElements.IndexOf(element);
    }

    public void FocusElement(TListItem element, bool isFallbackToButtonClose = true) => FocusElement(pool.ActiveElements.IndexOf(element), isFallbackToButtonClose);
    public int GetSelectedElement() => pool.ActiveElements[GetSelectedIndex()];

    // pool

    bind unbind

    // list item events
    OnClicked








}
