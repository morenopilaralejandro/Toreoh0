public static class DebugUtils 
{
    public static bool IsDevBuild 
    {
        get 
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
                return true;
            #else
                return false;
            #endif
        }
    }
}
