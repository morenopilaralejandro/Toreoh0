using UnityEngine;

[CreateAssetMenu(fileName = "AddressableConfig", menuName = "ScriptableObject/Addressable/AddressableConfig")]
public class AddressableConfig : ScriptableObject
{
    [Header("Cache Size")]
    public int CacheLruSize;
    public int CacheLruAudioClipSfx;

    [Header("Address Patch")]
    public string SeparatorPathMain = "-";
    public string SeparatorPathSub = "_";
    public string PathCharacterPortrait = "character-portrait";
}
