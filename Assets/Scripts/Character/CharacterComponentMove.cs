using System.Collections.Generic;
using Aremoreno.Enums.Character;
using Aremoreno.Enums.Move;

public class CharacterComponentMove
{
    private Character character;

    public List<Move> ListLearned = new ();
    public List<MoveLearnsetMapping> ListMoveLearnsetMapping = new ();

    // if weapon equipped, weapon move else default character move
    public Move DefaultMoveMelee;
    public Move DefaultMoveRange;
    public Move MoveMelee;
    public Move MoveRange;

    public CharacterComponentMove(CharacterData data, Character character) 
    {
        this.character = character;
        BuildLearnset(data);
        DefaultMoveMelee = MoveFactory.CreateById(data.MoveIdMelee);
        DefaultMoveRange = MoveFactory.CreateById(data.MoveIdRange);

        MoveMelee = DefaultMoveMelee;
        MoveRange = DefaultMoveRange;
    }

    public void SetMoveMelee(Move move) => MoveMelee = move;
    public void SetMoveRange(Move move) => MoveRange = move;

    public static Move Create(MoveData data) => new Move(data);
    public static Move CreateById(string id) => Create(DatabaseManager.Instance.DatabaseRegistry.MoveData.Get(id));

    // learnset
    private void BuildLearnset(CharacterData data)
    {
        ListMoveLearnsetMapping.Add(new MoveLearnsetMapping { MoveId = data.MoveId0, Level = data.MoveLv0 });
        ListMoveLearnsetMapping.Add(new MoveLearnsetMapping { MoveId = data.MoveId1, Level = data.MoveLv1 });
        ListMoveLearnsetMapping.Add(new MoveLearnsetMapping { MoveId = data.MoveId2, Level = data.MoveLv2 });
        ListMoveLearnsetMapping.Add(new MoveLearnsetMapping { MoveId = data.MoveId3, Level = data.MoveLv3 });
    }

    public void TryLearnByLevel(int level) 
    {
        foreach (var mapping in ListMoveLearnsetMapping) 
            if (mapping.Level <= level && !IsLearned(mapping.MoveId))
                Learn(mapping.MoveId);
    }

    // learn
    public void Learn(string id) => Learn(MoveFactory.CreateById(id));
    public void Learn(Move move) 
    {
        ListLearned.Add(move);
    }

    public bool IsLearned(string id) 
    {
        foreach (var m in ListLearned)
            if (m.MoveComponentAttributes.MoveId == id)
                return true;
        return false;
    }
    public bool IsLearned(Move move) 
    {
        foreach (var m in ListLearned)
            if (m.MoveComponentAttributes.MoveId == move.MoveComponentAttributes.MoveId)
                return true;
        return false;
    }

    public bool CanLearn(string id) 
    {
        return !IsLearned(id);
    }
    public bool CanLearn(Move move) 
    {
        return !IsLearned(move);
    }

    // aford
    public bool IsAffordable(Move move) => character.CharacterComponentStatsMp.IsAffordable(move.MoveComponentAttributes.Cost);
}
