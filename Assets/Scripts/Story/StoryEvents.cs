using System;

public static class StoryEvents
{
    public static event Action<string, bool> OnStoryFlagChanged;
    public static void RaiseStoryFlagChanged(string flagId, bool boolValue)
        => OnStoryFlagChanged?.Invoke(flagId, boolValue);
}
