using UnityEngine;
using Aremoreno.Enums.Input;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public InputActionMap<InputNavigation> Navigation { get; private set; }

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

        InputStateTracker<InputNavigation> trackerNavigation = new InputStateTracker<InputNavigation>();
        Navigation = new InputActionMapNavigation();
        Navigation.Initialize(inputActions, trackerNavigation);
    }

    private void Update() 
    {
        //Only update the ones that need held
        //Navigation.Tracker.Update();
    }

}
