using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class MoveUI : MonoBehaviour
{
    [SerializeField] private Image imageEvolution;
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textDescription;
    [SerializeField] private TMP_Text textCost;
    [SerializeField] private TMP_Text textPowerBase;
    [SerializeField] private CanvasGroup canvasGroupEvolution;
    [SerializeField] private Color colorCostDefault;
    [SerializeField] private Color colorCostNotAffordable;

    private readonly AddressableBinding<Sprite> bindingEvolution = new();
    private int version;

    public void OnDestroy() => Clear();

    public void Clear()
    {
        if (imageEvolution != null)
            imageEvolution.sprite = null;
        bindingEvolution.CancelAndRelease();
        version++;

        if (textName != null) textName.text = string.Empty;
        if (textDescription != null) textDescription.text = string.Empty;
        if (textCost != null) textCost.text = string.Empty;
        // if (textPowerBase != null) textPowerBase.text = string.Empty;
    }

    public async Task SetAsync(Move move, bool isAffordable = true)
    {
        SetData(move, isAffordable);
        await SetAsyncEvolution("");
    }

    private async Task SetAsyncEvolution(string address)
    {
        if (imageEvolution == null) return;
        UIUtils.SetCanvasGroupAlpha(canvasGroupEvolution, false);
        int auxVersion = ++version;
        var sprite = await bindingEvolution.LoadAssetAsync(address);
        if (version != auxVersion) return;
        imageEvolution.sprite = sprite;
        UIUtils.SetCanvasGroupAlpha(canvasGroupEvolution, true);
    }

    public void SetData(Move move, bool isAffordable = true)
    {
        if (textName != null) textName.text = move.MoveComponentLocalization.Name;
        if (textDescription != null) textDescription.text = move.MoveComponentLocalization.Description;
        if (textCost != null) textCost.text = move.MoveComponentAttributes.Cost.ToString();
        //if (textPowerBase != null) textPowerBase.text = countRequired.ToString();

        if (isAffordable)
            textCost.color = colorCostNotAffordable;
        else
            textCost.color = colorCostNotAffordable;
    }
}
