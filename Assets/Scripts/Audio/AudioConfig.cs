using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "ScriptableObject/Audio/AudioConfig")]
public class AudioConfig : ScriptableObject
{
    [Header("Cache Size")]
    public int CacheLruAudioClipSfx; //10

    [Header("Values")]
    public float FactorSfxLoopVolume; //0.7f
    public float MinIntervalPerSfxUI; //0.05f
}
