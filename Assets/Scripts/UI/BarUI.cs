using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BarUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private List<BarUIMapping> listBarUIMapping;
    [SerializeField] private Image imageBar;
    [SerializeField] private bool isLerpEnable;
    private float timeAnimation = 0.5f;
    private float timeElapsed;
    private Coroutine coroutineLerp;
    private ColorManager colorManager;    
    
    public void Start() 
    {
        colorManager = ColorManager.Instance;
        ChangeColorByMapping(slider.value);
    }

    public void SetValue(float floatValueCurrent, float floatValueMax, bool isInstant = false) => SetValue(floatValueCurrent/floatValueMax, isInstant);
    public void SetValue(float floatValue, bool isInstant = false)
    {
        if (isInstant || !isLerpEnable) 
        {
            ChangeColorByMapping(floatValue);
            slider.value = floatValue;
            return;
        }

        if (coroutineLerp != null)
        {
            StopCoroutine(coroutineLerp);
            coroutineLerp = null;
        }

        coroutineLerp = StartCoroutine(LerpValue(slider.value, floatValue));
    }

    private void ChangeColorByMapping(float floatValue) 
    {
        foreach(var mapping in listBarUIMapping)
        {
            if (floatValue < mapping.ThresholdBar) 
            {
                imageBar.color = colorManager.Palettes.Color.Get(mapping.ColorGeneric);
                break;
            }
        }
    }

    private IEnumerator LerpValue(float floatValueCurrent, float floatValueTarget)
    {
        timeElapsed = 0;
        while(timeElapsed < timeAnimation)
        {
            slider.value = Mathf.Lerp(floatValueCurrent, floatValueTarget, timeElapsed / timeAnimation);
            timeElapsed += Time.deltaTime;
            ChangeColorByMapping(slider.value);
            yield return null;
        }
    }
}
