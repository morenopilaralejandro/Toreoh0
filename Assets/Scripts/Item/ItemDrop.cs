[System.Serializable]
public class ItemDrop
{
    public string ItemId;
    public int CountMin = 1;
    public int CountMax = 1;
    [Range(0f, 1f)]
    public float DropChance = 1f;
}
