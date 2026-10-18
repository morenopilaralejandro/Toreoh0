using System.Collections.Generic;

public class ItemManagerComponentUsage
{
    public void UseItemOnCharacter(Item item)
    {
        switch (item)
        {
            case ItemRecovery itemRecovery:
                break;
            case ItemMove itemMove:
                break;
        }
    }
}
