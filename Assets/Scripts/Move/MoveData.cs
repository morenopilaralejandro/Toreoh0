using UnityEngine;
using Aremoreno.Enums.Character;
using Aremoreno.Enums.Move;

[CreateAssetMenu(fileName = "MoveData", menuName = "ScriptableObject/Move/MoveData")]
public class MoveData : ScriptableObject
{
    public string MoveId;
    public string BulletPatternId;
    public Element Element;
    public MoveCategory MoveCategory;
    public MoveCommandType MoveCommandType;
    public int FrameRecovery;
}
