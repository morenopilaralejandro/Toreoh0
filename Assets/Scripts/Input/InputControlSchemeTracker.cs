using UnityEngine.InputSystem;
using System.Collections.Generic;
using Aremoreno.Enums.Input;

public class InputControlSchemeTracker
{
    public ControlScheme CurrentControlScheme { get; private set; }
    public ControlScheme PreviousControlScheme { get; private set; }
    private Dictionary<string, ControlScheme> map;
    private PlayerInput playerInput;
    private InputConfig config;

    public void Initialize(
        InputConfig config,
        PlayerInput playerInput,
        List<InputControlSchemeMapping> mappings) 
    {
        this.config = config;
        BuildMap(mappings);
        playerInput.onControlsChanged += OnControlsChanged;
        // OnControlsChanged(playerInput);
    }

    private void OnControlsChanged(PlayerInput playerInput) 
    {
        string schemeString = playerInput.currentControlScheme;
        ControlScheme scheme = map[schemeString];
        UpdateControlScheme(scheme);
    }

    private void UpdateControlScheme(ControlScheme newControlScheme)
    {
        if (CurrentControlScheme == newControlScheme) return;
        PreviousControlScheme = CurrentControlScheme;
        CurrentControlScheme = newControlScheme;
        InputEvents.RaiseControlSchemeChanged(CurrentControlScheme);
    }

    public void BuildMap(List<InputControlSchemeMapping> mappings) 
    {
        map = new Dictionary<string, ControlScheme>();
        foreach(var mapping in mappings)
            map[mapping.ControlSchemeName] = mapping.ControlScheme;
    }

    public bool ShouldAutoFocus()
    {
        #if UNITY_EDITOR || DEVELOPMENT_BUILD
            return !config.IsDebugTouchInput;
        #else
            return CurrentControlScheme != ControlScheme.Touch;
        #endif
    }

    public bool IsExecuteOnClick()
    {
        #if UNITY_EDITOR || DEVELOPMENT_BUILD
            return !config.IsDebugTouchInput;
        #else
            return CurrentControlScheme != ControlScheme.Touch;
        #endif
    }

    // event
    /*

    public void Subscribe() 
    {
        playerInput.onControlsChanged += OnControlsChanged;
    }

    public void Unsubscribe() 
    {
        playerInput.onControlsChanged -= OnControlsChanged;
    }

    */
}
