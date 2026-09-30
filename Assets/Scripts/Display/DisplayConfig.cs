using UnityEngine;

[CreateAssetMenu(fileName = "DisplayConfig", menuName = "ScriptableObject/Display/DisplayConfig")]
public class DisplayConfig : ScriptableObject
{
    public Rect RectTopSingle       = new(0f, 0.5f, 1f, 0.5f);
    public Rect RectBottomSingle    = new(0f, 0f, 1f, 0.5f);
    public Rect RectDouble          = new(0f, 0f, 1f, 1f);

    public int TargetDisplayTopDouble = 0;
    public int TargetDisplayBottomDouble = 1;
    public int TargetDisplaySingle = 0;
}
