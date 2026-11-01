using System.Collections.Generic;
using System.Linq;

public class SelectorWingSource : ISelectorSource<Wing>
{
    public IEnumerable<Wing> Enumerate() => WingManager.Instance.WingManagerComponentStorage.
        DictWing.Values.OrderBy(obj => obj.WingComponentAttributes.WingId);
}
