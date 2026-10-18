using UnityEngine;

public static class WorldConstants 
{
    // chunkStreaming
    public const float CHUNK_SIZE = 16f;
    public const float TILES_PER_CHUNK = 16f;
    public const float TILE_SIZE = 1f;
    public const float TILE_OFFSET = 0.5f;
    public const float INTERIOR_SIZE = 48f;
    public const float CHUNK_STREAMING_UPDATE_INTERVAL = 1f;
    public const int CHUNK_STREAMING_RADIUS = 1;

    // tag
    public const string TAG_CHARACTER_MAIN = "CharacterMain";
    public const string TAG_TRANSITION = "CharacterMain";
    public const string TAG_INTERACTABLE = "Interactable";

    // chest
    public const string CHEST_ADDRESS_SPRITE_CLOSED = "sprite-chest-closed";
    public const string CHEST_ADDRESS_SPRITE_OPENED = "sprite-chest-opened";
    public const string CHEST_DIALOG_KNOT_OPEN = "ink_chest_open";
    public const string CHEST_DIALOG_KNOT_EMPTY = "ink_chest_empty";

    // gizmos
    public static Color GizmosColorTransitionTrigger = Color.green;
    public static Color GizmosColorSpawnPoint = Color.green;
    public static Color GizmosColorSpawnPointDirection = Color.orange;

    public static Color GizmosColorSceneRootDefaultFill = Color.green;
    public static Color GizmosColorSceneRootDefaultOutline = Color.orange;
    public static Color GizmosColorSceneRootSelectedFill = Color.green;
    public static Color GizmosColorSceneRootSelectedOutline = Color.red;
    public static Color GizmosColorSceneRootSelectedLine = Color.yellow;
    public const float GizmosAlphaSceneRootFill = 0.1f;
}
