using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialogConfig", menuName = "ScriptableObject/Dialog/DialogConfig")]
public class DialogConfig : ScriptableObject
{
    [Header("Ink Story")]
    public List<InkStoryMapping> StoryMappings = new ();

    [Header("Speaker")]
    public int CacheSpeakerCapacity;

    [Header("Smart String Arguments")]
    public string SmartStringArgumentRegexPattern; //  -->   \{(\w+)\}
}
