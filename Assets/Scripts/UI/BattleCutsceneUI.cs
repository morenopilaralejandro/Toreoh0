using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Character;

public class BattleCutsceneUI: MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CanvasGroup canvasGroupEvolution;
    [SerializeField] private Image imageEvolution;
    [SerializeField] private TMP_Text textName;

    private readonly AddressableBinding<Sprite> bindingEvolution = new();
    private int version;

    public void OnDestroy() => Clear();

    public void Clear()
    {
        imageEvolution.sprite = null;
        bindingEvolution.CancelAndRelease();
        version++;
    }

    public async Task SetAsync(string name, string addressEvolution)
    {
        await SetAsyncEvolution(addressEvolution);
        textName.text = name;
        UIUtils.SetCanvasGroupAlpha(canvasGroup, true);
    }

    public async Task SetAsyncEvolution(string address)
    {
        if (string.IsNullOrEmpty(address)) return;
        UIUtils.SetCanvasGroupAlpha(canvasGroupEvolution, false);
        int auxVersion = ++version;
        var sprite = await bindingEvolution.LoadAssetAsync(address);
        if (version != auxVersion) return;
        imageEvolution.sprite = sprite;
        UIUtils.SetCanvasGroupAlpha(canvasGroupEvolution, true);
    }

    // Event
    private void OnEnable()
    {               
        UIEvents.OnCutsceneBattleStarted += OnCutsceneBattleStarted;
        UIEvents.OnCutsceneBattleEnded += OnCutsceneBattleEnded;
    }

    private void OnDisable()
    {
        UIEvents.OnCutsceneBattleStarted -= OnCutsceneBattleStarted;
        UIEvents.OnCutsceneBattleEnded -= OnCutsceneBattleEnded;
    }

    private void OnCutsceneBattleStarted(string name, string addressEvolution) 
    {
        _ = SetAsync(name, addressEvolution);
    }

    private void OnCutsceneBattleEnded() 
    {
        UIUtils.SetCanvasGroupAlpha(canvasGroup, false);
        UIUtils.SetCanvasGroupAlpha(canvasGroupEvolution, false);
    }
}
