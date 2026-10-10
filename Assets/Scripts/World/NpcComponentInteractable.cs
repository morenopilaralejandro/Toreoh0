using UnityEngine;

public class NpcComponentInteractable : InteractableMonoBehaviour
{
    [SerializeField] DialogComponentStarter dialogStarterComponent;

    public override void Interact() 
    {
        dialogStarterComponent.StartDialog();
    }
}
