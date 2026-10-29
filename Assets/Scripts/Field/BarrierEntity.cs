using UnityEngine;
using System.Threading.Tasks;

public class BarrierEntity : MonoBehaviour
{
    public BarrierComponentAppearanceBattle AppearanceComponentBattle;
    public Barrier Barrier;

    public void Initialize(BarrierData data)
    {
        Barrier = BarrierFactory.Create(data);
        AppearanceComponentBattle.Initialize(this);
    }

    public async Task LoadAsync()
    {
        await AppearanceComponentBattle.SetAsync();
    }

    public void OnDestroy()
    {
        AppearanceComponentBattle.Clear();
    }
}
