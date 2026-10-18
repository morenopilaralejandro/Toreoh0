using UnityEngine;

public class CharacterTriggerInteraction : MonoBehaviour
{
    [SerializeField] CharacterIndicatorInteraction indicator;
    private InteractableComponentCollider interactableCollider;

    protected void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag(WorldConstants.TAG_INTERACTABLE)) return;
        interactableCollider = other.GetComponent<InteractableComponentCollider>();
        indicator.SetEnabled(true);
    }

    protected void OnTriggerExit2D(Collider2D other) 
    {
        if (!other.CompareTag(WorldConstants.TAG_INTERACTABLE)) return;
        interactableCollider = null;
        indicator.SetEnabled(false);
    }

    public void PerformInteraction() => interactableCollider?.Interactable.Interact();
}
