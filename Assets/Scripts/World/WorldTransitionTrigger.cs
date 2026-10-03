using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class WorldTransitionTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip sfx;
    [SerializeField] private bool isInteractionRequired = false;
    private string tagCharacterMain = "CharacterMain";

    private AudioManager audioManager;
    private WorldManager worldManager;

    private WorldTransitionTriggerComponentStateMachine stateComponent;

    protected void Awake() 
    {
        stateComponent = new WorldTransitionTriggerComponentStateMachine();
        audioManager = AudioManager.Instance;
        worldManager = WorldManager.Instance;
    }

    protected void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag(tagCharacterMain)) return;
        if (isInteractionRequired)
        {
            stateComponent.SetState(WorldTransitionTriggerState.CharacterInTrigger);
            // TODO event show interaction indicator
        } else 
        {
            Transition();
        }
    }

    protected void OnTriggerExit2D(Collider2D other) 
    {
        if (!other.CompareTag(tagCharacterMain)) return;
        stateComponent.SetState(WorldTransitionTriggerState.Idle);
        // TODO event hide interaction indicator
    }

    public void Interact() 
    {
        if (stateComponent.State != WorldTransitionTriggerState.CharacterInTrigger) return;
        Transition();
    }

    protected virtual void Transition() 
    {
        if (stateComponent.State == WorldTransitionTriggerState.Transitioning) return;
        stateComponent.SetState(WorldTransitionTriggerState.Transitioning);
        if (sfx != null) audioManager.Sfx.Play(sfx);
    }

    protected void OnDrawGizmos() 
    {
        GizmosUtils.DrawCollider2D(GetComponent<Collider2D>(), Color.green, true)
    }
}
