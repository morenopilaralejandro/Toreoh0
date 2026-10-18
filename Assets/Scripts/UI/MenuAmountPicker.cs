using UnityEngine;
using System;
using TMPro;
using Aremoreno.Enums.Input;

public abstract class MenuAmountPicker : Menu
{
    //[Header("UI References")]
    [SerializeField] private TMP_Text textCount;
    protected int countCurrent;
    protected int countMin;
    protected int countMax;

    // Lifecycle

    // Input
    public virtual void OnButtonConfirmClicked() 
    {
        RequestClose();
    }

    public void OnButtonAdd1Clicked() => ChangeCount(1);
    public void OnButtonAdd10Clicked() => ChangeCount(10);
    public void OnButtonRemove1Clicked() => ChangeCount(-1);
    public void OnButtonRemove10Clicked() => ChangeCount(-10);

    // Logic
    protected virtual void ChangeCount(int delta) 
    {
        if (delta < 0 && countCurrent == countMin)
            countCurrent = countMax;
        else if (delta > 0 && countCurrent == countMax)
            countCurrent = countMin;
        else 
            countCurrent = Math.Clamp(countCurrent + delta, countMin, countMax);

        textCount.text = countCurrent.ToString();
    }
}
