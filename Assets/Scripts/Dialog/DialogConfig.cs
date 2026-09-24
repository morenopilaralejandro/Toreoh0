using UnityEngine;

[CreateAssetMenu(fileName = "DialogConfig", menuName = "ScriptableObject/Dialog/DialogConfig")]
public class DialogConfig : ScriptableObject
{
    //[Header("Dialog")]
    //public char TableNameSeparator;

    [Header("Smart String Arguments")]
    public string SmartStringArgumentRegexPattern; //  -->   \{(\w+)\}
}
