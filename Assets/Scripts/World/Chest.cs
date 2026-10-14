public class Chest 
{
    public ChestComponentAttributes AttributesComponent;
    public ChestComponentStateMachine StateMachineComponent;
    public ChestComponentContent ContentComponent;
    public ChestComponentPersistence PersistenceComponent;

    public Chest(ChestData data)
    {
        AttributesComponent = new ChestComponentAttributes(data);
        StateMachineComponent = new ChestComponentStateMachine();
        ContentComponent = new ChestComponentContent(data);
        PersistenceComponent = new ChestComponentPersistence(this, StoryManager.Instance.ChestTracker);
    }
}
