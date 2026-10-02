using UnityEngine;
using UnityEditor.SceneManagement;

[CreateAssetMenu(fileName = "SceneSetupGroupData", menuName = "ScriptableObject/SceneSetup/SceneSetupGroupData")]
public class SceneSetupGroupData : ScriptableObject
{
    [Header("Localization")]
    public SceneSetup[] SceneSetupArray;
}
