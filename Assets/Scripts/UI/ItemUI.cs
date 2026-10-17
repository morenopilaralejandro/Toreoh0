using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image imageIcon;
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textDescription;
    [SerializeField] private TMP_Text textCountOwned;
    [SerializeField] private TMP_Text textCountRequired;

    private readonly AddressableBinding<Sprite> binding = new();
    private int version;

    public void OnDestroy() => Clear();

    public void Clear()
    {
        if (imageIcon != null)
            imageIcon.sprite = null;
        binding.CancelAndRelease();
        version++;

        if (textName != null) textName.text =  string.Empty;
        if (textDescription != null) textDescription.text = string.Empty;
        if (textCountOwned != null) textCountOwned.text = string.Empty;
        if (textCountRequired != null) textCountRequired.text = string.Empty;
    }

    public async Task SetAsync(string itemId, int countOwned = 0, int countRequired = 0)
        => await SetAsync(ItemFactory.CreateById(itemId), countOwned, countRequired);

    public async Task SetAsync(Item item, int countOwned = 0, int countRequired = 0)
    {
        SetData(item, countOwned, countRequired);
        await SetAsyncInternal(item.AppearanceComponent.AddressIcon);
    }

    private async Task SetAsyncInternal(string address) 
    {
        if (imageIcon == null) return;
        int auxVersion = ++version;
        var sprite = await binding.LoadAssetAsync(address);
        if (version != auxVersion) return;
        imageIcon.sprite = sprite;
    }

    private void SetData(Item item, int countOwned, int countRequired)
    {
        if (textName != null) textName.text = item.LocalizationComponent.ItemName;
        if (textDescription != null) textDescription.text = item.LocalizationComponent.ItemDescription;
        if (textCountOwned != null) textCountOwned.text = countOwned.ToString();
        if (textCountRequired != null) textCountRequired.text = countRequired.ToString();
    }
}
