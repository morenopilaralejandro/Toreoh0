using UnityEngine;
using System.Threading.Tasks;
using Aremoreno.Enums.Battle;

public class ProtectObstacleComponentAppearanceBattle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private readonly AddressableBinding<Sprite> binding = new();

    private ProtectObstacleEntity protectObstacleEntity;
 
    public void Initialize(ProtectObstacleEntity protectObstacleEntity)
    {
        this.protectObstacleEntity = protectObstacleEntity;
    }

    public void Clear()
    {
        spriteRenderer.sprite = null;
        binding.CancelAndRelease();
    }

    public async Task SetAsync() 
    {
        string address = protectObstacleEntity.ProtectObstacle.AppearanceComponent.DictAddressSprite[protectObstacleEntity.ProtectObstacle.StateMachineComponent.State];
        var sprite = await binding.LoadAssetAsync(address);
        spriteRenderer.sprite = sprite;
    }
}
