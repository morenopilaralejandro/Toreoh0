using System.Collections.Generic;
using System.Linq;

public class SelectorMoveSourceLearned : ISelectorSource<Move>
{
    public Character Character;

    public SelectorMoveSourceLearned(Character character) 
    {
        Character = character;
    }

    public IEnumerable<Move> Enumerate() => Character.CharacterComponentMove.ListLearned;

    /*
    public IEnumerable<Move> Enumerate() => MoveManager.Instance.MoveManagerComponentStorage.a
        DictMove.Values.OrderBy(obj => obj.MoveComponentAttributes.MoveId);
    */
}
