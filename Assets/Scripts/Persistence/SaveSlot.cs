public class SaveSlot 
{
    public int SlotIndex { get; private set; }
    public PersistenceSaver Saver { get; private set; }
    public PersistenceLoader Loader { get; private set; }

    public SaveSlot(int slotIndex, PersistenceConfig config) 
    {
        SlotIndex = slotIndex;
        PersistenceWriter writer = new PersistenceWriter(slotIndex, config);
        Saver = new PersistenceSaver(config, writer);
        Loader = new PersistenceLoader(config, writer);
    }
}
