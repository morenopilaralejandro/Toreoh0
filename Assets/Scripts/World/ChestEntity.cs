using UnityEngine;
using System.Threading.Tasks;
using Aremoreno.Enums.World;

public class ChestEntity : MonoBehaviour, IAsyncSceneLoader
{
    [SerializeField] private ChestData data;
    [SerializeField] private ChestComponentAppearanceWorld appearanceComponent;
    [SerializeField] private ChestComponentInteractable interactableComponent;
    public Chest Chest;

    public async Task LoadAsync()
    {
        Initialize(data);
        await appearanceComponent.SetAsync(Chest.StateMachineComponent.State);
    }

    private void Initialize(ChestData data) 
    {
        Chest = ChestFactory.Create(data);
        interactableComponent.Initialize(this, DialogManager.Instance, StoryManager.Instance.ChestTracker);

        if (Chest.PersistenceComponent.IsOpened) 
            Chest.StateMachineComponent.SetState(ChestState.Opened);
        else 
            Chest.StateMachineComponent.SetState(Chest.AttributesComponent.DefaultState);
    }

    public void Open() 
    {
        Chest.PersistenceComponent.TrackOpen();
        Chest.StateMachineComponent.SetState(ChestState.Opened);
        _ = appearanceComponent.SetAsync(Chest.StateMachineComponent.State);
    }

    private void OnDrawGizmos() 
    {
        if (data == null) return;
        UnityEditor.Handles.Label(
            transform.position,
            $"{data.ChestId}[{data.ItemId}]"
        );
    }
}
