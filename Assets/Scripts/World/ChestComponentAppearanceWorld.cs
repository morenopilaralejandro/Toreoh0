using UnityEngine;
using System.Threading.Tasks;
using Aremoreno.Enums.World;

public class ChestComponentAppearanceWorld : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private string address = string.Empty;

    private readonly AddressableBinding<Sprite> binding = new();
    private int version;

    public void OnDestroy() => Clear();

    public void Clear()
    {
        spriteRenderer.sprite = null;
        binding.CancelAndRelease();
        version++;
    }

    public async Task SetAsync(ChestState state) 
    {
        SetAddress(state);

        int auxVersion = ++version;
        var sprite = await binding.LoadAssetAsync(address);
        if (version != auxVersion) return;
        spriteRenderer.sprite = sprite;
    }

    private void SetAddress(ChestState state) 
    {
        switch(state) 
        {
            case ChestState.Opened:
                address = WorldConstants.CHEST_ADDRESS_SPRITE_OPENED;
                break;
            default:
                address = WorldConstants.CHEST_ADDRESS_SPRITE_CLOSED;
                break;
        }
    }
}
