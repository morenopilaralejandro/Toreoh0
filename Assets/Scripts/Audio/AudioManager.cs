using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SereializeField] private AudioSource sourceBgm;
    [SereializeField] private AudioSource sourceSfxDefault;
    [SereializeField] private AudioSource sourceSfxLoop;
    [Header("Config")]
    [SereializeField] private AudioConfig config;

    private IAudioLoader loaderWithCache;
    private IAudioLoader loaderWithoutCache;
    private IAudioPlayer audioPlayer

    public AudioChannelSfxDefault Sfx { get; private set; }
    public AudioChannelSfxLoop SfxLoop { get; private set; }
    public AudioChannelSfxUI SfxUI { get; private set; }
    public AudioChannelBgm Bgm { get; private set; }

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void Initialize() 
    {

    }

    public void Clear() 
    {
        Sfx.Clear();
        SfxLoop.Clear();
        SfxUI.Clear();
        Bgm.Clear();
    }

    //event

    private void OnEnable() 
    {
        SettingsEvent.OnVolumeBgmChanged += HandleVolumeBgmChanged;
        SettingsEvent.OnVolumeSfxChanged += HandleVolumeSfxChanged;
    }

    private void OnDisable() 
    {
        SettingsEvent.OnVolumeBgmChanged -= HandleVolumeBgmChanged;
        SettingsEvent.OnVolumeSfxChanged -= HandleVolumeSfxChanged;
    }

    private void HandleVolumeBgmChanged(float volume) 
    {
        Bgm.SetVolume(volume);
    }

    private void HandleVolumeSfxChanged(float volume) 
    {
        Sfx.SetVolume(volume);
        SfxUI.SetVolume(volume);
        SfxLoop.SetVolume(volume);
    }

    */
}
