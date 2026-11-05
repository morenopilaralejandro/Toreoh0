using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenToWorldConverter
{
    private InputConfig config;
    private Camera cameraMain;
    private Plane planeGround;

    public void Initialize(InputConfig config, Camera cameraMain) 
    {
        this.config = config;
        this.cameraMain = cameraMain;
        planeGround = new Plane(Vector3.up, new Vector3(0, config.GroundY, 0));
    }

    public Vector3 GetPositionOnGround(Vector2 screenPosition)
    {
        Ray ray = cameraMain.ScreenPointToRay(screenPosition);
        if(planeGround.Raycast(ray, out float distance))
            return ray.GetPoint(distance);
        return Vector3.zero;
    }

    public bool IsTouchingLayer(Vector2 screenPosition, LayerMask layer)
    {
        Ray ray = cameraMain.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer))
            return true;
        return false;
    }

    public bool IsTouchingUI()
    {
        return EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject();
    }
}
