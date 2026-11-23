using Aremoreno.Enums.Move;

public class SelectorMoveFilterSpecial : ISelectorFilter<Move>
{
    public bool Matches(Move obj) => obj.MoveComponentAttributes.MoveCommandType == MoveCommandType.Special;

}
