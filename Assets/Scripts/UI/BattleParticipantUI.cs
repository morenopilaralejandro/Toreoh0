using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;
using Aremoreno.Enums.Battle;
using Aremoreno.Enums.Character;

public class BattleParticipantUI: MonoBehaviour
{
    [SerializeField] private BattleSide battleSide;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image imageBackground;
    [SerializeField] private CharacterPortraitUIBattle characterPortraitUIBattle;
    [SerializeField] private TMP_Text textName;
    [SerializeField] private BarUI barHp;
    [SerializeField] private BarUI barMp;

    private CharacterEntityBattle entity;

    public void OnDestroy() => Clear();

    public void Clear()
    {
        characterPortraitUIBattle.Clear();
        entity = null;
    }

    public async Task SetAsync(CharacterEntityBattle entity) 
    {
        this.entity = entity;
        await characterPortraitUIBattle.SetAsync(entity.Character);
        UIUtils.SetCanvasGroupAlpha(canvasGroup, true);
    }

    // background
    private void SetBackgroundColor(BattleSide battleSide) 
    {
        // adapt for 2vs2
        imageBackground.color = ColorManager.Instance.Palettes.BattleSide.Get(battleSide);
    }

    // helper
    private bool IsValidCharacter(CharacterEntityBattle entity) => entity != null && this.entity != null && entity.Character.CharacterComponentAttributes.CharacterGuid == this.entity.Character.CharacterComponentAttributes.CharacterGuid;

    // Event
    private void OnEnable()
    {               
        UIEvents.OnBattleParticipantUpdateRequeted += OnBattleParticipantUpdateRequeted;
        UIEvents.OnCharacterHpDecreased += OnCharacterHpDecreased;
        UIEvents.OnCharacterMpDecreased += OnCharacterMpDecreased;
    }

    private void OnDisable()
    {
        UIEvents.OnBattleParticipantUpdateRequeted -= OnBattleParticipantUpdateRequeted;
        UIEvents.OnCharacterHpDecreased -= OnCharacterHpDecreased;
        UIEvents.OnCharacterMpDecreased -= OnCharacterMpDecreased;
    }

    private void OnBattleParticipantUpdateRequeted(CharacterEntityBattle entity) 
    {
        if (entity == null) return;
        if (entity.Character.CharacterComponentSide.BattleSide != this.battleSide) return;
        SetBackgroundColor(entity.Character.CharacterComponentSide.BattleSide);
        _ = SetAsync(entity);
        barHp.SetValue(entity.Character.CharacterComponentStats.GetStatNormalized(Stat.Hp), isInstant : true);
        barMp.SetValue(entity.Character.CharacterComponentStatsMp.GetMpNormalized(), isInstant : true);
        //textName.text = entity.Character.asd;
    }

    private void OnCharacterHpDecreased(CharacterEntityBattle entity) 
    {
        if (IsValidCharacter(entity)) 
            barHp.SetValue(entity.Character.CharacterComponentStats.GetStatNormalized(Stat.Hp), isInstant : false);
    }

    private void OnCharacterMpDecreased(CharacterEntityBattle entity) 
    {
        if (IsValidCharacter(entity))
            barMp.SetValue(entity.Character.CharacterComponentStatsMp.GetMpNormalized(), isInstant : false);
    }
}
