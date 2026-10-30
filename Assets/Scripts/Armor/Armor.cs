public class Armor 
{
    public ArmorComponentAttributes ArmorComponentAttributes;
    public ArmorComponentPersistence ArmorComponentPersistence;

    public Armor(ArmorData data)
    {
        ArmorComponentAttributes = new ArmorComponentAttributes(data);
        ArmorComponentPersistence = new ArmorComponentPersistence(this);
    }
}
