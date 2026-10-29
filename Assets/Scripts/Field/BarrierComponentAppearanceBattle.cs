using UnityEngine;
using System.Threading.Tasks;
using Aremoreno.Enums.Battle;

public class BarrierComponentAppearanceBattle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private readonly AddressableBinding<Sprite> binding = new();

    private BarrierEntity BarrierEntity;
 
    public void Initialize(BarrierEntity BarrierEntity)
    {
        this.BarrierEntity = BarrierEntity;
    }

    public void Clear()
    {
        spriteRenderer.sprite = null;
        binding.CancelAndRelease();
    }

    public async Task SetAsync() 
    {
        var sprite = await binding.LoadAssetAsync(BarrierEntity.Barrier.AppearanceComponent.AddressSprite);
        spriteRenderer.sprite = sprite;
    }
}
