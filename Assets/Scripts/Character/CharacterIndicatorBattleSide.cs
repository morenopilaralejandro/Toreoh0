using UnityEngine;
using Aremoreno.Enums.Battle;

public class CharacterIndicatorBattleSide : MonoBehaviour
{
    [SerializeField] private SpriteRenderer indicator;

    public void SetBattleSide(BattleSide battleSide)
    {
        indicator.color = ColorManager.Instance.Palettes.BattleSide.Get(battleSide);
    }
}
