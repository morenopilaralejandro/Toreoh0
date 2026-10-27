using UnityEngine;
using System.Threading.Tasks;
using Aremoreno.Enums.Battle;

public class ProtectObstacleComponentAppearanceBattle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private readonly AddressableBinding<Sprite> binding = new();
    private int version;

    private ProtectObstacleEntity protectObstacleEntity;
 
    public void Initialize(ProtectObstacleEntity protectObstacleEntity)
    {
        this.protectObstacleEntity = protectObstacleEntity;
    }

    public void Clear()
    {
        spriteRenderer.sprite = null;
        binding.CancelAndRelease();
        version++;
    }

    public async Task SetAsync() 
    {
        string address = protectObstacleEntity.ProtectObstacle.AppearanceComponent.DictAddressSprite[protectObstacleEntity.ProtectObstacle.StateMachineComponent.State];

        int auxVersion = ++version;
        var sprite = await binding.LoadAssetAsync(address);
        if (version != auxVersion) return;
        spriteRenderer.sprite = sprite;
    }
}
