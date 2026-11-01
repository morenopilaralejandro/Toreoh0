using System.Collections.Generic;
using System.Linq;

public class SelectorArmorSource : ISelectorSource<Armor>
{
    public IEnumerable<Armor> Enumerate() => ArmorManager.Instance.ArmorManagerComponentStorage.
        DictArmor.Values.OrderBy(obj => obj.ArmorComponentAttributes.ArmorId);
}
