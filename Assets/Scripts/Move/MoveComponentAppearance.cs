public class MoveComponentAppearance
{
    public string AddressSpriteElement;
    public string AddressSpriteMoveCategory;

    public MoveComponentAppearance(MoveData data) 
    {
        AddressSpriteElement = AddressableBuilder.GetElementIconAddress(data.Element.ToString().ToLower());
        AddressSpriteMoveCategory = AddressableBuilder.GetMoveCategoryIconAddress(data.MoveCategory.ToString().ToLower());
    }
}
