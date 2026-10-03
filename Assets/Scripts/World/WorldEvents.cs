using System;

public static class WorldEvents 
{
    public static event Action<ZoneData, ZoneData, string> OnZoneChanged;
    public static void RaiseZoneChanged(ZoneData zonePrevious, ZoneData zoneCurrent, string zoneCurrentName)
        => OnZoneChanged.Invoke(zonePrevious, zoneCurrent, zoneCurrentName);
}
