using UnityEngine;
using TMPro;
using Aremoreno.Enums.Item;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textGold;
    [SerializeField] private TMP_Text textPremium;
    [SerializeField] private TMP_Text textExpertTokens;
    [SerializeField] private TMP_Text textTrainingPoints;
    private ItemManagerComponentCurrency currencyComponent;

    private void Awake()
    {
        if (ItemManager.Instance == null) return;
        currencyComponent = ItemManager.Instance.CurrencyComponent;
    }

    public void OnDestroy() => Clear();

    public void Clear()
    {
        if (textGold != null) textGold.text =  string.Empty;
        if (textPremium != null) textPremium.text = string.Empty;
        if (textExpertTokens != null) textExpertTokens.text = string.Empty;
        if (textTrainingPoints != null) textTrainingPoints.text = string.Empty;
    }

    public void SetData()
    {
        if (textGold != null) textGold.text = currencyComponent.Get(CurrencyType.Gold).ToString();
        if (textPremium != null) textPremium.text = currencyComponent.Get(CurrencyType.Premium).ToString();
        if (textExpertTokens != null) textExpertTokens.text = currencyComponent.Get(CurrencyType.ExpertTokens).ToString();
        if (textTrainingPoints != null) textTrainingPoints.text = currencyComponent.Get(CurrencyType.TrainingPoints).ToString();
    }

    // event
    private void OnEnable()
    {
        ItemEvents.OnCurrencyUpdated += OnCurrencyUpdated;
    }

    private void OnDisable() 
    {
        ItemEvents.OnCurrencyUpdated -= OnCurrencyUpdated;
    }

    private void OnCurrencyUpdated(CurrencyType currencyType, int count) 
    {
        switch (currencyType)
        {
            case CurrencyType.Gold:
                if(textGold != null) textGold.text = count.ToString();
                break;
            case CurrencyType.Premium:
                if(textPremium != null) textPremium.text = count.ToString();
                break;
            case CurrencyType.ExpertTokens:
                if(textExpertTokens != null) textExpertTokens.text = count.ToString();
                break;
            case CurrencyType.TrainingPoints:
                if(textTrainingPoints != null) textTrainingPoints.text = count.ToString();
                break;
        }
    }
}
