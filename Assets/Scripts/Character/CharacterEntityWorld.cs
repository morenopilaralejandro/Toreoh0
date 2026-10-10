using UnityEngine;
using Aremoreno.Enums.Animation;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.World;

public class CharacterEntityWorld : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D colliderObstacles;
    [SerializeField] private CharacterTriggerInteraction interactionComponent;
    private CharacterComponentStateMachineWorld StateMachineWorld;

    public void Awake() 
    {
        StateMachineWorld = new CharacterComponentStateMachineWorld();
        StateMachineWorld.Subscribe();
    }

    public void OnDestroy() 
    {
        StateMachineWorld?.Unsubscribe();
    }

    private void Update() 
    {
        if(StateMachineWorld.State != WorldStateCharacter.Freeroam) 
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        rb.linearVelocity = InputManager.Instance.MapBattle.Move * 20f;

        if (InputManager.Instance.MapBattle.Tracker.GetDown(InputBattle.Shoot)) 
        {
            SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-World");
            SceneLoaderManager.Instance.LoadGroup("SceneGroupData-DebugMainMenu");
        }

        if (InputManager.Instance.MapBattle.Tracker.GetDown(InputBattle.Pass)) 
        {
            if (colliderObstacles.enabled)
                OnIsNoClipEnabledChanged(true);
            else
                OnIsNoClipEnabledChanged(false);
        }

        if (InputManager.Instance.MapWorld.Tracker.GetDown(InputWorld.Interact)) 
        {
            CustomLog.Warning("button pressed");
            interactionComponent.PerformInteraction();
        }
    }

    public void Teleport(Vector3 pos)
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = pos;
        transform.position = pos;
        WorldEvents.RaiseCharacterTeleported(pos);
    }

    public void SetFacing(CharacterDirection direction)
    {
        
    }

    private void OnEnable() 
    {
        WorldEvents.OnIsNoClipEnabledChanged += OnIsNoClipEnabledChanged;
    }

    private void OnDisable() 
    {
        WorldEvents.OnIsNoClipEnabledChanged -= OnIsNoClipEnabledChanged;
    }

    private void OnIsNoClipEnabledChanged(bool isEnabled) => colliderObstacles.enabled = !isEnabled;
}
