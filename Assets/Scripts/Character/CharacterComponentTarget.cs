using Aremoreno.Enums.Battle;

public class CharacterComponentTarget
{
    private CharacterEntityBattle characterEntityBattle;
    public BattleSide BattleSide;

    public int IndexTargetTeam;
    public int IndexTargetCharacter;
    public CharacterEntityBattle TargetEntity;

    public void SetIndexTargetTeam(int indexTargetTeam) => IndexTargetTeam = indexTargetTeam;
    public void SetIndexTargetCharacter(int indexTargetCharacter) => IndexTargetCharacter = indexTargetCharacter;
    public void SetTargetEntity(CharacterEntityBattle targetEntity) => TargetEntity = targetEntity;

    public CharacterComponentTarget(CharacterEntityBattle characterEntityBattle) 
    {
        this.characterEntityBattle = characterEntityBattle;
    }
}
