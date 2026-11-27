using UnityEngine;
using TMPro;
using Aremoreno.Enums.Battle;

public class BattleMessageUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private LocalizationComponentUIText textLocalizationMessage;
    [SerializeField] private TMP_Text textMessage;
    [SerializeField] private CanvasGroup canvasGroup;

    // Lifecycle

    // Event
    private void OnEnable()
    {
        UIEvents.OnBattleMessageStarted += OnBattleMessageStarted;
        UIEvents.OnBattleMessageEnded += OnBattleMessageEnded;
    }

    private void OnDisable()
    {
        UIEvents.OnBattleMessageStarted -= OnBattleMessageStarted;
        UIEvents.OnBattleMessageEnded -= OnBattleMessageEnded;
    }

    private void OnBattleMessageStarted(BattleMessage battleMessage)
    {
        textLocalizationMessage.SetData(BattleManager.Instance.Battle.BattleComponentConfig.BattleConfig.DictBattleMessageMapping[battleMessage].ListMappingReference);
        textMessage.color = ColorManager.Instance.Palettes.BattleMessage.Get(battleMessage);
        UIUtils.SetCanvasGroupAlpha(canvasGroup, true);
    }

    private void OnBattleMessageEnded() 
    {
        UIUtils.SetCanvasGroupAlpha(canvasGroup, false);
    }
}
