using UnityEngine;

[CreateAssetMenu(fileName = "AddressableConfig", menuName = "ScriptableObject/Addressable/AddressableConfig")]
public class AddressableConfig : ScriptableObject
{
    [Header("Cache Size")]
    public int CacheLruSize;

    [Header("Address Patch")]
    public string SeparatorPathMain;
    public string SeparatorPathSub;
    public string PathCharacterPortrait;
    public string PathItemIcon;
    public string PathProtectObstacleSprite;
    public string PathFieldTileMap;
    public string PathBarrierPrefab;
}
