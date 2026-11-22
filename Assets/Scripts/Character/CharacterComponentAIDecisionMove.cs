using System;
using Aremoreno.Enums.Move;

public class CharacterComponentAIDecisionMove
{
    private CharacterEntityBattle entity;
    public bool HasSpecialMoveMelee;
    public bool HasSpecialMoveRange;
    private Move move;
    private bool isFound;
    private int indexMelee;
    private int indexRange;
    private int countTotal;
    private int clampMax;

    public CharacterComponentAIDecisionMove(CharacterEntityBattle entity) 
    {
        this.entity = entity;
        countTotal = entity.Character.CharacterComponentMove.ListLearned.Count;
        clampMax = countTotal - 1;
        foreach(Move move in entity.Character.CharacterComponentMove.ListLearned)
        {
            if (move.MoveComponentAttributes.MoveCommandType == MoveCommandType.Normal) continue;
            if (move.MoveComponentAttributes.MoveCategory == MoveCategory.Melee)
                HasSpecialMoveMelee = true;
            else 
                HasSpecialMoveRange = true;
            if (HasSpecialMoveMelee && HasSpecialMoveRange) break;
        }
    }

    public Move GetSpecialMoveMeleeSecuencial()
    {
        if (!HasSpecialMoveMelee) return entity.Character.CharacterComponentMove.MoveMelee;

        isFound = false;
        while (!isFound) 
        {
            move = entity.Character.CharacterComponentMove.ListLearned[indexMelee];
            if (move.MoveComponentAttributes.MoveCommandType == MoveCommandType.Special && move.MoveComponentAttributes.MoveCategory == MoveCategory.Melee)
                isFound = true;
            indexMelee = ClampIndex(indexMelee);
        }
        return move;
    }

    public Move GetSpecialMoveRangeSecuencial()
    {
        if (!HasSpecialMoveRange) return entity.Character.CharacterComponentMove.MoveRange;
        
        isFound = false;
        while (!isFound) 
        {
            move = entity.Character.CharacterComponentMove.ListLearned[indexRange];
            if (move.MoveComponentAttributes.MoveCommandType == MoveCommandType.Special && move.MoveComponentAttributes.MoveCategory == MoveCategory.Range)
                isFound = true;
            indexRange = ClampIndex(indexRange);
        }
        return move;
    }

    private int ClampIndex(int index) 
    {
        index++;
        if (index > clampMax)
            return 0;
        else
            return index;
    }
}
