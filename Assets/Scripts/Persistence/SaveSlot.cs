public class SaveSlot 
{
    public int SlotIndex { get; private set; }
    public PersistenceWriter Writer { get; private set; }
    public PersistenceSaver Saver { get; private set; }
    public PersistenceLoader Loader { get; private set; }

    public SaveSlot(int slotIndex, PersistenceConfig config) 
    {
        SlotIndex = slotIndex;
        Writer = new PersistenceWriter(slotIndex, config);
        Saver = new PersistenceSaver(config, Writer);
        Loader = new PersistenceLoader(config, Writer);
    }
}
