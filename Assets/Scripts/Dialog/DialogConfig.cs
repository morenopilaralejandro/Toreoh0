using UnityEngine;

[CreateAssetMenu(fileName = "DialogConfig", menuName = "ScriptableObject/Dialog/DialogConfig")]
public class DialogConfig : ScriptableObject
{
    [Header("Ink Story")]
    public List<StoryMapping> StoryMappings = new ();

    [Header("Speaker")]
    public int CacheSpeakerCapacity;

    [Header("Smart String Arguments")]
    public string SmartStringArgumentRegexPattern; //  -->   \{(\w+)\}
}
