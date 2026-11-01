using System.Collections.Generic;
using System.Linq;

public class SelectorMoveSourceLearned : ISelectorSource<Move>
{
    // TODO use character component moves
    public IEnumerable<Move> Enumerate() => new List<Move>();


    /*
    public IEnumerable<Move> Enumerate() => MoveManager.Instance.MoveManagerComponentStorage.a
        DictMove.Values.OrderBy(obj => obj.MoveComponentAttributes.MoveId);
    */
}
