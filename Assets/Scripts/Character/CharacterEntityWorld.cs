using UnityEngine;
using Aremoreno.Enums.Animation;
using Aremoreno.Enums.Input;
using Aremoreno.Enums.World;

public class CharacterEntityWorld : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
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
    }

    public void Teleport(Vector3 pos)
    {
        rb.position = pos;
        WorldEvents.RaiseCharacterTeleported(pos);
    }

    public void SetFacing(CharacterDirection direction)
    {
        
    }
}
