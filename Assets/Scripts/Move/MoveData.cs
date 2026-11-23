using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Character;
using Aremoreno.Enums.Move;

[CreateAssetMenu(fileName = "MoveData", menuName = "ScriptableObject/Move/MoveData")]
public class MoveData : ScriptableObject
{
    public string MoveId;
    public string SfxAddress;
    public Element Element;
    public MoveCategory MoveCategory;
    public MoveCommandType MoveCommandType;
    public int Cost;
    public int FrameRecovery;
    public List<BulletPatternMapping> ListBulletPatternMapping;
}
