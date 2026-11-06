using UnityEngine;
using Aremoreno.Enums.Battle;

[CreateAssetMenu(fileName = "TeamData", menuName = "ScriptableObject/Team/TeamData")]
public class TeamData : ScriptableObject
{
    public string TeamId;
    public string CharacterPointId0;
    public string CharacterPointId1;
    public string CharacterAssistId0;
    public string CharacterAssistId1;
}
