using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource sourceBgm;
    [SerializeField] private AudioSource sourceSfxDefault;
    [SerializeField] private AudioSource sourceSfxLoop;

    [Header("Config")]
    [SerializeField] private AudioConfig config;

    private CacheLru<string, AudioClip> cacheSfx;
    private IAudioLoader loaderWithCache;
    private IAudioLoader loaderWithoutCache;
    private IAudioPlayer player;

    public AudioChannel Sfx { get; private set; }
    public AudioChannel SfxLoop { get; private set; }
    public AudioChannel SfxUI { get; private set; }
    public AudioChannel Bgm { get; private set; }

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
        cacheSfx = new CacheLru<string, AudioClip>(config.CacheLruAudioClipSfx);
        loaderWithCache = new AudioLoaderWithCache();
        loaderWithCache.Initialize(cacheSfx);
        loaderWithoutCache = new AudioLoaderWithoutCache();
        player = new AudioPlayer();

        Sfx = new AudioChannelSfxDefault(
            config,
            sourceSfxDefault,
            loaderWithCache,
            player,
            isLoop : false);

        SfxLoop = new AudioChannelSfxLoop(
            config,
            sourceSfxLoop,
            loaderWithCache,
            player,
            isLoop : true);

        SfxUI = new AudioChannelSfxUI(
            config,
            sourceSfxDefault,
            loaderWithCache,
            player,
            isLoop : false);

        Bgm = new AudioChannelBgm(
            config,
            sourceSfxDefault,
            loaderWithoutCache,
            player,
            isLoop : true);
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
        SettingsEvents.OnVolumeBgmChanged += HandleVolumeBgmChanged;
        SettingsEvents.OnVolumeSfxChanged += HandleVolumeSfxChanged;
    }

    private void OnDisable() 
    {
        SettingsEvents.OnVolumeBgmChanged -= HandleVolumeBgmChanged;
        SettingsEvents.OnVolumeSfxChanged -= HandleVolumeSfxChanged;
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
}
