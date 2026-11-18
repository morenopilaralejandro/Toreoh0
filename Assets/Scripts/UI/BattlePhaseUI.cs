using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Aremoreno.Enums.Battle;

public class BattlePhaseUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textName;
    [SerializeField] private LocalizationComponentUIText textNameUI;

    //public void OnDestroy() => Clear();
    //public void Clear() { }

    // event
    private void OnEnable()
    {               
        BattleEvents.OnBattlePhaseChanged += OnBattlePhaseChanged;
    }

    private void OnDisable()
    {
        BattleEvents.OnBattlePhaseChanged -= OnBattlePhaseChanged;
    }

    private void OnBattlePhaseChanged(BattlePhase battlePhaseNew, BattlePhase battlePhaseOld) 
    {
        textName.color = ColorManager.Instance.Palettes.BattlePhase.Get(battlePhaseNew);
        textNameUI.SetData(BattleManager.Instance.BattleConfig.DictBattlePhaseMapping[battlePhaseNew].ListLocalizationReferenceStyleMapping);
    }
}
