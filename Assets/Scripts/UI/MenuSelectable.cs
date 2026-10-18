using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelectable : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData baseEventData) 
    {
        UIEvents.RaiseSelectableSelected(gameObject);
    }
}
