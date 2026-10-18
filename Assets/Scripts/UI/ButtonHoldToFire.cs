using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonHoldToFire : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Button button;
    [SerializeField] private float initialDelay = 0.4f;
    [SerializeField] private float repeatInterval = 0.1f;
    [SerializeField] private string sfx = "sfx-ui_tap";
    private Coroutine holdCoroutine;

    public void OnPointerDown(PointerEventData pointerEventData) => holdCoroutine = StartCoroutine(HoldRoutine());
    public void OnPointerUp(PointerEventData pointerEventData) => StopHold();
    
    private IEnumerator HoldRoutine() 
    {
        yield return new WaitForSeconds(initialDelay);
        while(true) 
        {
            _ = AudioManager.Instance.SfxUI.Play(sfx);
            button.onClick.Invoke();
            yield return new WaitForSeconds(repeatInterval);
        }
    }
    
    private void StopHold() 
    {
        if (holdCoroutine == null) return;
        StopCoroutine(holdCoroutine);
        holdCoroutine = null;
    }

    private void OnDisable() 
    {
        StopHold();
    }
}
