using System.Collections.Generic;
using Aremoreno.Enums.Battle;

public class ProtectObstacleComponentAppearance
{
    public Dictionary<ProtectObstacleState, string> DictAddressSprite = new ();

    public string AddressProtectObstacleSprite;

    public ProtectObstacleComponentAppearance(ProtectObstacleData data) 
    {
        foreach (var enumValue in EnumUtils.GetValues<ProtectObstacleState>())
            DictAddressSprite[enumValue] = AddressableBuilder.GetProtectObstacleSpriteAddress(
                data.ProtectObstacleId,
                enumValue.ToString().ToLower()
            );
    }
}
