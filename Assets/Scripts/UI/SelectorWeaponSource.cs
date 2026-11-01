using System.Collections.Generic;
using System.Linq;

public class SelectorWeaponSource : ISelectorSource<Weapon>
{
    public IEnumerable<Weapon> Enumerate() => WeaponManager.Instance.WeaponManagerComponentStorage.
        DictWeapon.Values.OrderBy(obj => obj.WeaponComponentAttributes.WeaponId);
}
