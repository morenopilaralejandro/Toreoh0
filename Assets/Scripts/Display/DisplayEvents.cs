using System;
using Aremoreno.Enums.Display;

public static class DisplayEvents 
{
    public static event Action OnDisplayRefreshRequested;
    public static void RaiseDisplayRefreshRequested() 
        => OnDisplayRefreshRequested?.Invoke();
}
