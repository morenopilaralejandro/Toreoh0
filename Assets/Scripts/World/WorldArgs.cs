using UnityEngine;
using Aremoreno.Enums.Animation;
using Aremoreno.Enums.World;

public static class WorldArgs
{
    public static string ZoneId;
    public static Vector3 CharacterPosition;
    public static CharacterDirection CharacterFacingDirection;
    public static WorldState WorldState;
    public static int Hour;

    // set
    public static void SetFromWorld() 
    {
        if (WorldManager.Instance == null) return;
        CharacterPosition = WorldManager.Instance.CharacterMain.transform.position;
        CharacterFacingDirection = CharacterDirection.Up;
        Hour = 0;
    }

    // persistence
    public static WorldManagerSaveData Export() 
    {
        return new WorldManagerSaveData 
        {
            ZoneId = WorldArgs.ZoneId,
            CharacterPositionX = WorldArgs.CharacterPosition.x,
            CharacterPositionY = WorldArgs.CharacterPosition.y,
            CharacterPositionZ = WorldArgs.CharacterPosition.z,
            CharacterFacingDirection = WorldArgs.CharacterFacingDirection,
            Hour = WorldArgs.Hour
        };
    }

    public static void Import(WorldManagerSaveData saveData) 
    {
        WorldArgs.ZoneId = saveData.ZoneId;
        WorldArgs.CharacterPosition = new Vector3(saveData.CharacterPositionX, saveData.CharacterPositionY, saveData.CharacterPositionZ);
        WorldArgs.CharacterFacingDirection = saveData.CharacterFacingDirection;
        WorldArgs.Hour = saveData.Hour;
    }
}
