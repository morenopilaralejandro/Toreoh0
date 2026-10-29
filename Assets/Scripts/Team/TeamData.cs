using UnityEngine;
using Aremoreno.Enums.Battle;

[CreateAssetMenu(fileName = "TeamData", menuName = "ScriptableObject/Team/TeamData")]
public class TeamData : ScriptableObject
{
    public string TeamId;
    public string Character0Id;
    public string Character1Id;
    public string Assist0Id;
    public string Assist1Id;
}
