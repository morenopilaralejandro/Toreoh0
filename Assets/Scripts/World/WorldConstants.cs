using UnityEngine;

public static class WorldConstants 
{
    // chunkStreaming
    public static float CHUCK_SIZE = 16f;
    public static float TILES_PER_CHUNK = 16f;
    public static float TILE_SIZE = 1f;
    public static float TILE_OFFSET = 0.5f;
    public static float INTERIOR_SIZE = 48f;
    public static float CHUCK_STREAMING_UPDATE_INTERVAL = 2f;
    public static int CHUCK_STREAMING_RADIUS = 2;

    // tag
    public static string TAG_CHARACTER_MAIN = "CharacterMain";

    // gizmos
    public static Color GizmosColorTransitionTrigger = Color.green;
    public static Color GizmosColorSpawnPoint = Color.green;
    public static Color GizmosColorSpawnPointDirection = Color.orange;

    public static Color GizmosColorSceneRootDefaultFill = Color.green;
    public static Color GizmosColorSceneRootDefaultOutline = Color.orange;
    public static Color GizmosColorSceneRootSelectedFill = Color.green;
    public static Color GizmosColorSceneRootSelectedOutline = Color.red;
    public static Color GizmosColorSceneRootSelectedLine = Color.orange;
    public static float GizmosAlphaSceneRootFill = 0.1f;
}
