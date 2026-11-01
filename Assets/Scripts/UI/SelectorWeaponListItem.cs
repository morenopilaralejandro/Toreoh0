using UnityEngine;

public class SelectorWeaponListItem : SelectorListItem<Weapon>
{
    //[SerializeField] private ItemUI itemUI;

    public override void SetData(Weapon data)
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

    private void HandleOnSelected(SelectorListItem<Weapon> listItem) 
    {
        // UIEvents.RaiseItemOverviewUpdateRequested(listItem.Data);
    }
}
