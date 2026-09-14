using UnityEngine;

[CreateAssetMenu(fileName = "UIConfig", menuName = "ScriptableObject/UI/UIConfig")]
public class UIConfig : ScriptableObject
{
    [Header("Audio Feedback")]
    public float thresholdScrollViewSfx; //0.02f
    public float thresholdScrollBarSfx; //0.02f
}
