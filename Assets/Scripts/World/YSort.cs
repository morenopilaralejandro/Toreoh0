using UnityEngine;
using UnityEngine.Rendering;

public class YSort : MonoBehaviour
{
    [SerializeField] private Transform sortPoint;
    [SerializeField] private SortingGroup sortingGroup;
    [SerializeField] private int offset;
    private Transform sortReference;
    private WorldManager worldManager;

    private void Start()
    {
        sortReference = Camera.main.transform;
        worldManager = WorldManager.Instance;
        //worldManager.YSortComponent.Register(this);
    }

    private void Destroy()
    {
        //worldManager?.YSortComponent.Unregister(this);
    }

    public void OnLateUpdateInternal()
    {
        float relativeY = sortPoint.position.y - sortReference.position.y;
        sortingGroup.sortingOrder = -(int)(relativeY * 10 + offset);
    }
}
