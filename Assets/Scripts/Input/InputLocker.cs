using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InputLocker 
{
    public bool IsLocked { get; private set; }
    private PlayerInput playerInput;
    private List<IInputActionMap> maps;

    public void Initialize(
        PlayerInput playerInput,
        List<IInputActionMap> maps)
    {
        this.playerInput = playerInput;
        this.maps = maps;
    }

    public void Lock() 
    {
        if (IsLocked) return;
        IsLocked = true;
        playerInput.DeactivateInput();
        foreach (var map in maps)
            map.Reset();
    }

    public void Unlock() 
    {
        if (!IsLocked) return;
        IsLocked = false;
        playerInput.ActivateInput();
    }
}
