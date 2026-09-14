using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "ScriptableObject/Audio/AudioConfig")]
public class AudioConfig : ScriptableObject
{
    [Header("Cache Size")]
    public int CacheLruAudioClipSfx;

    [Header("Values")]
    public int FactorSfxLoopVolume; //0.7f
    public float MinIntervalPerSfxUI; //0.05f
}
