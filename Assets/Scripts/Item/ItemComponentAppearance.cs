using UnityEngine;
using Aremoreno.Enums.Color;
using Aremoreno.Enums.Item;

public class ItemComponentAppearance
{
    public ItemSpriteType ItemSpriteType;
    public ColorGeneric ColorGeneric;
    public Color Color;
    public string AddressIcon;

    public ItemComponentAppearance(ItemData data) 
    {
        ItemSpriteType = data.ItemSpriteType;
        ColorGeneric = data.ColorGeneric;
        Color = ColorManager.Instance.Palettes.Color.Get(ColorGeneric);
        AddressIcon = AddressableBuilder.GetItemIconAddress(data.ItemSpriteType.ToString().ToLower());
    }
}
