using System;
using Aremoreno.Enums.Input;

public static class InputEvents 
{
    public static event Action<ControlScheme> OnControlSchemeChanged;

    /*
    public static event Action<string> OnSceneGroupLoaded;
    public static void RaiseSceneGroupLoaded(string sceneGroupId) 
        => OnSceneGroupLoaded.Invoke(sceneGroupId);
    */
}
