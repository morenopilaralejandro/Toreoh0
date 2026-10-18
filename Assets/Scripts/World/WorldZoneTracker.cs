using UnityEngine;

public class WorldZoneTracker
{
    public ZoneData ZoneCurrent { get; private set; }
    public ZoneData ZonePrevious { get; private set; }
    public ZoneComponentLocalization LocalizationComponent { get; private set; }

    private AudioManager audioManager;

    public WorldZoneTracker(AudioManager audioManager) 
    {
        this.audioManager = audioManager;
    }

    public void SetZone(ZoneData zoneNew) 
    {
        if (zoneNew == ZoneCurrent || zoneNew == null) return;
        ZonePrevious = ZoneCurrent;
        ZoneCurrent = zoneNew;
        UpdateLocalization();
        UpdateBgm();

        // TODO FastTravelTracker.TryAddZone(zoneData);
        WorldEvents.RaiseZoneChanged(ZonePrevious, ZoneCurrent, LocalizationComponent.ZoneName);
    }


    private void UpdateLocalization() 
    {
        LocalizationComponent = new ZoneComponentLocalization(ZoneCurrent);
    }

    private void UpdateBgm() 
    {
        if (ZoneCurrent.Bgm == null) return;
        AudioClip bgmPrevious = ZonePrevious == null ? null : ZonePrevious.Bgm;
        if (bgmPrevious == ZoneCurrent.Bgm) return;
        audioManager.Bgm.Play(ZoneCurrent.Bgm);
    }
}
