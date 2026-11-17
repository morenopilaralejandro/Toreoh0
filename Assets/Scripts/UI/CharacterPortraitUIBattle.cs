using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class CharacterPortraitUIBattle: MonoBehaviour
{
    [SerializeField] private Image imageCharacterPortrait;
    [SerializeField] private CanvasGroup canvasGroupCharacter;

    private readonly AddressableBinding<Sprite> bindingCharacter = new();

    private int version;

    public void OnDestroy() => Clear();

    public void Clear()
    {
        UIUtils.SetCanvasGroupVisible(canvasGroupCharacter, false);
        imageCharacterPortrait.sprite = null;
        bindingCharacter.CancelAndRelease();
        version++;
    }

    public async Task SetAsync(Character character) 
    {
        int auxVersion = ++version;
        var spriteCharacter = await bindingCharacter.LoadAssetAsync(character.CharacterComponentAppearance.AddressSpritePortrait);
        if (version != auxVersion) return;
        imageCharacterPortrait.sprite = spriteCharacter;
        UIUtils.SetCanvasGroupAlpha(canvasGroupCharacter, true);
    }
}
