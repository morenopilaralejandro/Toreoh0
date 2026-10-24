using UnityEngine;
using System.Collections.Generic;

public class MenuComponentTabs : MonoBehaviour
{
    [SerializeField] private CanvasGroup defaultCanvasGroup;
    [SerializeField] private List<CanvasGroup> listCanvasGroup;

    private void Awake()
    {
        OnButtonTabClicked(defaultCanvasGroup);
    }

    private void HideAll() 
    {
        foreach (var canvasGroup in listCanvasGroup)
            UIUtils.SetCanvasGroupVisible(canvasGroup, false);
    }

    public void OnButtonTabClicked(CanvasGroup canvasGroup) 
    {
        HideAll();
        UIUtils.SetCanvasGroupVisible(canvasGroup, true);
    }
}
