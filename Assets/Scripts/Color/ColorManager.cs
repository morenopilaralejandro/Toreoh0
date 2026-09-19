using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }

    [Header("Config")]
    [SerializeField] private ColorConfig Palettes;

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
        foreach(var dict in Palettes.GetAllDictionaries())
            dict.Initialize();
    }
}
