using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private InputConfig config;
    [SerializeField] private PlayerInput playerInput;

    public InputActionMapBattle MapBattle { get; private set; }
    public InputActionMapWorld MapWorld { get; private set; }
    public InputActionMapDialog MapDialog { get; private set; }
    public InputActionMapNavigation MapNavigation { get; private set; }
    public InputLocker Locker { get; private set; }
    public InputControlSchemeTracker ControlSchemeTracker { get; private set; }

    // Lifecycle
    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void Initialize() 
    {
        InputActionsGame inputActions = new InputActionsGame();

        InputStateTracker<InputBattle> trackerBattle = new InputStateTracker<InputBattle>();
        MapBattle = new InputActionMapBattle();
        MapBattle.Initialize(inputActions, trackerBattle);

        InputStateTracker<InputWorld> trackerWorld = new InputStateTracker<InputWorld>();
        MapWorld = new InputActionMapWorld();
        MapWorld.Initialize(inputActions, trackerWorld);

        InputStateTracker<InputDialog> trackerDialog = new InputStateTracker<InputDialog>();
        MapDialog = new InputActionMapDialog();
        MapDialog.Initialize(inputActions, trackerDialog);

        InputStateTracker<InputNavigation> trackerNavigation = new InputStateTracker<InputNavigation>();
        MapNavigation = new InputActionMapNavigation();
        MapNavigation.Initialize(inputActions, trackerNavigation);

        Locker = new InputLocker();
        List<IInputActionMap> maps = new ();
        maps.Add(MapBattle);
        Locker.Initialize(playerInput, maps);

        ControlSchemeTracker = new InputControlSchemeTracker();
        ControlSchemeTracker.Initialize(playerInput, config.ControlSchemeMappings);
    }

    /*
    private void Update() 
    {
        Only update the ones that need held buttons
        MapBattle.Tracker.Update();
    }
    */
}
