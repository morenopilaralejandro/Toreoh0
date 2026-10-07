using UnityEngine;
using UnityEngine.Rendering;

public class YSort : MonoBehaviour
{
    [SerializeField] private Transform sortPoint;
    [SerializeField] private SortingGroup sortingGroup;
    [SerializeField] private int offset;
    private Transform sortReference;

    private void Awake()
    {
        sortReference = Camera.main.transform;
    }

    private void OnLateUpdate()
    {
        float relativeY = sortPoint.position.y - sortReference.position.y;
        sortingGroup.sortingOrder = -(int)(relativeY * 10 + offset);
    }
}
