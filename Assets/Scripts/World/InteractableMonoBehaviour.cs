using UnityEngine;

public abstract class InteractableMonoBehaviour : MonoBehaviour, IInteractable 
{
    public abstract void Interact();
}
