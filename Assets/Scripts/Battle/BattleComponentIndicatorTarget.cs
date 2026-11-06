using UnityEngine;

public class BattleComponentIndicatorTarget : MonoBehaviour
{
    public void SetIndicator(CharacterEntityBattle entity) 
    {
        this.transform.SetParent(entity.transform, false);
    }
}
