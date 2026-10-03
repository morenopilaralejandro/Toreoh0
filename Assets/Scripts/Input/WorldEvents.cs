using System;
using Aremoreno.Enums.World;

public static class WorldEvents 
{
    public static event Action<ControlScheme> OnControlSchemeChanged;
    public static void RaiseControlSchemeChanged(ControlScheme controlScheme) 
        => OnControlSchemeChanged?.Invoke(controlScheme);
}
