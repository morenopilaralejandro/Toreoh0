public class ChestComponentPersistence
{
    private Chest chest;
    private ChestTracker chestTracker;

    public ChestComponentPersistence(Chest chest, ChestTracker chestTracker)
    {
        this.chest = chest;
        this.chestTracker = chestTracker;
    }

    public bool IsOpened => chestTracker.Contains(chest.AttributesComponent.ChestId);
    public void TrackOpen() => chestTracker.Add(chest.AttributesComponent.ChestId);
}
