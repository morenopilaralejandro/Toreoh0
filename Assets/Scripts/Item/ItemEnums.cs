namespace Aremoreno.Enums.Item
{
    public enum CurrencyType 
    {
        Gold,
        TrainingPoint
    }

    public enum ItemCategory 
    {
        // basic
        Material,
        Mics,
        Important,
        Recovery,
        // reference other systems
        Recipe,
        Character,
        Move,
        Wing,
        Weapon,
        Armor
    }

    public enum ItemSpriteType 
    {
        Basic
    }

    public enum ItemUsageContext 
    {
        Any,
        Battle,
        Overworld,
        Passive,
        None
    }
}
