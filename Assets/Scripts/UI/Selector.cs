using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Selector<TData, TListItem> : Menu, IMenuClosable where TListItem : SelectorListItem<TData>
{
    // fields
    [Header("Selector")]
    [SerializeField] protected Button buttonClose;
    [SerializeField] protected bool isCloseOnSelect = false;
    public ScrollViewPoolAdapter<TListItem> ScrollAdapter;

    protected ISelectorSource <TData> source;
    protected ISelectorActionClick <TData> actionClick;
    protected ISelectorFilter <TData> filter;

    // override
    protected override void Start() 
    {
        ScrollAdapter = new ();
        ScrollAdapter.Initialize(OnGetElement, OnReleaseElement);
    }

    public override void Show()
    {
        base.Show();
        Refresh();
        ScrollAdapter.SetScrollActive(true);
    }

    public override void Hide() 
    {
        ScrollAdapter.SetScrollActive(false);
        ScrollAdapter.PoolWrapper.Pool.Dispose();
        base.Hide();
    }

    public override void SetInteractable(bool isInteractable) 
    {
        base.SetInteractable(isInteractable);
        ScrollAdapter.SetScrollActive(isInteractable);
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

    public void Refresh() => ScrollAdapter.Populate(source.Enumerate(), Bind);

    // element
    public void FocusElement(int index, bool isFallbackToButtonClose = true) 
    {
        if ((index < 0 || ScrollAdapter.PoolWrapper.Pool.CountActive == 0) && isFallbackToButtonClose)
        {
            if (buttonClose != null) SetDefaultSelectable(buttonClose);
            return;
        }

        index = Mathf.Clamp(index, 0, ScrollAdapter.PoolWrapper.Pool.CountActive - 1); // fallback to first element
        SetDefaultSelectable(ScrollAdapter.PoolWrapper.Pool.ActiveElements[index].Button);
    }

    public void FocusElement(TListItem element, bool isFallbackToButtonClose = true) => FocusElement(ScrollAdapter.PoolWrapper.Pool.ActiveElements.IndexOf(element), isFallbackToButtonClose);

    public int GetSelectedIndex()
    {
        var currentSelected = EventSystem.current.currentSelectedGameObject;
        if (currentSelected == null) return -1;
        var element = currentSelected.GetComponent<TListItem>();
        if (element == null) return -1;
        return ScrollAdapter.PoolWrapper.Pool.ActiveElements.IndexOf(element);
    }

    public TListItem GetSelectedElement() 
    {
        int selectedIndex = GetSelectedIndex();
        if (selectedIndex < 0) return null;
        return ScrollAdapter.PoolWrapper.Pool.ActiveElements[selectedIndex];
    } 

    // bind and pool method
    protected virtual void OnGetElement(TListItem element) 
    {
        element.gameObject.SetActive(true);
        element.OnClicked += OnClicked;
    }

    protected virtual void OnReleaseElement(TListItem element) 
    {
        element.OnClicked -= OnClicked;
        element.Clear();
        element.gameObject.SetActive(false);
    }

    protected virtual void Bind(TListItem listItem, TData data)
    {
        listItem.SetData(data);
    }

    // list item events
    protected void OnClicked(SelectorListItem<TData> element) 
    {
        actionClick?.Execute(element.Data, this);
        if (isCloseOnSelect) RequestClose();
    }
}
