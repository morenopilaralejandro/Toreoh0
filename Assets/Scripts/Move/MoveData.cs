using UnityEngine;
using Aremoreno.Enums.Move;

[CreateAssetMenu(fileName = "MoveData", menuName = "ScriptableObject/Move/MoveData")]
public class MoveData : ScriptableObject
{
    public string MoveId;
    public string BulletPatternId;
    public MoveCategory MoveCategory;
    public MoveCommandType MoveCommandType;
    public int FrameRecovery;
}
