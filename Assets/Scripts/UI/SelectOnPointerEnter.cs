using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectOnPointerEnter : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Selectable selectable;
    private static Vector2 lastPosition;

    public void OnPointerEnter(PointerEventData pointerEventData) 
    {
        if (!selectable.IsInteractable()) return;
        if (EventSystem.current == null) return;
        if (EventSystem.current.alreadySelecting) return;
        if (EventSystem.current.currentSelectedGameObject == gameObject) return;
        if (pointerEventData.position == lastPosition) return;
        lastPosition = pointerEventData.position;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
