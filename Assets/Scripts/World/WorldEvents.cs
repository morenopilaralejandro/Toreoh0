using UnityEngine;
using System;

public static class WorldEvents 
{
    public static event Action<ZoneData, ZoneData, string> OnZoneChanged;
    public static void RaiseZoneChanged(ZoneData zonePrevious, ZoneData zoneCurrent, string zoneCurrentName)
        => OnZoneChanged?.Invoke(zonePrevious, zoneCurrent, zoneCurrentName);

    public static event Action<Vector3> OnCharacterTeleported;
    public static void RaiseCharacterTeleported(Vector3 pos)
        => OnCharacterTeleported?.Invoke(pos);
}
