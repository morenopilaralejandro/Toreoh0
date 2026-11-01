using UnityEngine;

public class SelectorCharacterListItem : SelectorListItem<Character>
{
    //[SerializeField] private ItemUI itemUI;

    public override void SetData(Character data)
    {
        base.SetData(data);
        //_ =  itemUI.SetAsync(data);
        OnSelected += HandleOnSelected;
    }

    public override void Clear()
    {
        //itemUI.Clear();
        OnSelected -= HandleOnSelected;
    }

    private void HandleOnSelected(SelectorListItem<Character> listItem) 
    {
        // UIEvents.RaiseItemOverviewUpdateRequested(listItem.Data);
    }
}
