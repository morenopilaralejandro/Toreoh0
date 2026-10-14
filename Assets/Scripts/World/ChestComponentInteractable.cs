using Aremoreno.Enums.World;

public class ChestComponentInteractable : InteractableMonoBehaviour
{
    private string knotName;
    private ChestEntity chestEntity;
    private DialogManager dialogManager;
    private ChestTracker chestTracker;

    public void Initialize(
        ChestEntity chestEntity, 
        DialogManager dialogManager, 
        ChestTracker chestTracker) 
    {
        this.chestEntity = chestEntity;
        this.dialogManager = dialogManager;
        this.chestTracker = chestTracker;
        knotName = string.Empty;
    }

    public override void Interact()
    {
        ResolveKnot(chestEntity.Chest.StateMachineComponent.State);
    }

    private void ResolveKnot(ChestState state)
    {
        switch(state) 
        {
            case ChestState.Opened:
                knotName = WorldConstants.CHEST_DIALOG_KNOT_EMPTY;
                break;
            case ChestState.Closed:
                knotName = WorldConstants.CHEST_DIALOG_KNOT_OPEN;
                chestTracker.SetCurrentOpeningChestId(chestEntity.Chest.AttributesComponent.ChestId);
                chestEntity.Open();
                break;
        }
        dialogManager.InkStoryComponent.StartDialog(knotName);
    }
}
