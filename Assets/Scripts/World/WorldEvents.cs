using UnityEngine;
using System;
using Aremoreno.Enums.World;

public static class WorldEvents 
{
    public static event Action<ZoneData, ZoneData, string> OnZoneChanged;
    public static void RaiseZoneChanged(ZoneData zonePrevious, ZoneData zoneCurrent, string zoneCurrentName)
        => OnZoneChanged?.Invoke(zonePrevious, zoneCurrent, zoneCurrentName);

    public static event Action<Vector3> OnCharacterTeleported;
    public static void RaiseCharacterTeleported(Vector3 pos)
        => OnCharacterTeleported?.Invoke(pos);

    public static event Action<WorldState, WorldState> OnWorldStateChanged;
    public static void RaiseWorldStateChanged(WorldState stateNew, WorldState stateOld)
        => OnWorldStateChanged?.Invoke(stateNew, stateOld);

    public static event Action<bool> OnIsNoClipEnabledChanged;
    public static void RaiseIsNoClipEnabledChanged(bool isEnabled)
        => OnIsNoClipEnabledChanged?.Invoke(isEnabled);
}
