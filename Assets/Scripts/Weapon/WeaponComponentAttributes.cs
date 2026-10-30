using Aremoreno.Enums.Battle;

public class WeaponComponentAttributes
{
    public string WeaponId;
    public string WeaponGuid;

    public WeaponComponentAttributes(WeaponData data) 
    {
        WeaponId = data.WeaponId;
        WeaponGuid = data.WeaponId;
    }
}
