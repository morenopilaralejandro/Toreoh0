using System;

public static class SceneEvents 
{
    public static event Action<string> OnSceneGroupLoaded;
    public static void RaiseSceneGroupLoaded(string sceneGroupId) 
        => OnSceneGroupLoaded.Invoke(sceneGroupId);
}
