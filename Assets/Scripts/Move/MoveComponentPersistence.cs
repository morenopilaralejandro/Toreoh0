public class MoveComponentPersistence
{
    private Move Move;

    public MoveComponentPersistence(Move Move)
    {
        this.Move = Move;
    }

    public MoveSaveData Export()
    {
        return null;
        /*
        return new MoveSaveData 
        {
            MoveManagerComponentStorageSaveData = MoveManager.StorageComponent.Export(),
            MoveManagerComponentCurrencySaveData = MoveManager.CurrencyComponent.Export()
        };
        */
    }
}
