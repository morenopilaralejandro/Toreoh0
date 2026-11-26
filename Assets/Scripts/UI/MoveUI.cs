using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class MoveUI : MonoBehaviour
{
    [SerializeField] private Image imageEvolution;
    [SerializeField] private Image imageElement;
    [SerializeField] private Image imageMoveCategory;
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textDescription;
    [SerializeField] private TMP_Text textCost;
    [SerializeField] private TMP_Text textPowerBase;
    [SerializeField] private Color colorCostDefault;
    [SerializeField] private Color colorCostNotAffordable;
    [SerializeField] private bool isNameColorEnabled;

    private readonly AddressableBinding<Sprite> bindingEvolution = new();
    private readonly AddressableBinding<Sprite> bindingElement = new();
    private readonly AddressableBinding<Sprite> bindingMoveCategory = new();
    private int versionEvolution;
    private int versionElement;
    private int versionMoveCategory;

    // lifecycle
    public void OnDestroy() => Clear();

    public void Clear()
    {
        bindingEvolution.CancelAndRelease();
        bindingElement.CancelAndRelease();
        bindingMoveCategory.CancelAndRelease();
        versionEvolution++;
        versionElement++;
        versionMoveCategory++;

        if (imageEvolution != null) imageEvolution.sprite = null;
        if (imageElement != null) imageElement.sprite = null;
        if (imageMoveCategory != null) imageMoveCategory.sprite = null;

        if (textName != null) textName.text = string.Empty;
        if (textDescription != null) textDescription.text = string.Empty;
        if (textCost != null) textCost.text = string.Empty;
        // if (textPowerBase != null) textPowerBase.text = string.Empty;
    }

    // async
    public async Task SetAsync(Move move, bool isAffordable = true)
    {
        SetData(move, isAffordable);
        await SetAsyncEvolution("");
        await SetAsyncElement(move.MoveComponentAppearance.AddressSpriteElement);
        await SetAsyncMoveCategory(move.MoveComponentAppearance.AddressSpriteMoveCategory);
    }

    private async Task SetAsyncEvolution(string address)
    {
        if (imageEvolution == null) return;
        imageEvolution.enabled = false;
        int auxVersion = ++versionEvolution;
        var sprite = await bindingEvolution.LoadAssetAsync(address);
        if (versionEvolution != auxVersion) return;
        imageEvolution.sprite = sprite;
        imageEvolution.enabled = true;
    }

    private async Task SetAsyncElement(string address)
    {
        if (imageElement == null) return;
        imageElement.enabled = false;
        int auxVersion = ++versionElement;
        var sprite = await bindingElement.LoadAssetAsync(address);
        if (versionElement != auxVersion) return;
        imageElement.sprite = sprite;
        imageElement.enabled = true;
    }

    private async Task SetAsyncMoveCategory(string address)
    {
        if (imageMoveCategory == null) return;
        imageMoveCategory.enabled = false;
        int auxVersion = ++versionMoveCategory;
        var sprite = await bindingMoveCategory.LoadAssetAsync(address);
        if (versionMoveCategory != auxVersion) return;
        imageMoveCategory.sprite = sprite;
        imageMoveCategory.enabled = true;
    }

    // set data
    public void SetData(Move move, bool isAffordable = true)
    {
        if (textName != null) textName.text = move.MoveComponentLocalization.Name;
        if (textDescription != null) textDescription.text = move.MoveComponentLocalization.Description;
        if (textCost != null) textCost.text = move.MoveComponentAttributes.Cost.ToString();
        //if (textPowerBase != null) textPowerBase.text = countRequired.ToString();

        // SetCostColor(isAffordable);

        if (isNameColorEnabled && textName != null)
            textName.color = ColorManager.Instance.Palettes.ElementText.Get(move.MoveComponentAttributes.Element);
    }

    // helper
    public void SetCostColor(bool isAffordable)
    {
        if (isAffordable && textCost != null)
            textCost.color = colorCostDefault;
        else
            textCost.color = colorCostNotAffordable;
    }
}
