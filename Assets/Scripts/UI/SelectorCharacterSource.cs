using System.Collections.Generic;
using System.Linq;

public class SelectorCharacterSource : ISelectorSource<Character>
{
    public IEnumerable<Character> Enumerate() => CharacterManager.Instance.CharacterManagerComponentStorage.
        DictCharacter.Values.OrderBy(obj => obj.CharacterComponentAttributes.CharacterId);
}
