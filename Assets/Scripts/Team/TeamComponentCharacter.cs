using System.Collections.Generic;

public class TeamComponentCharacter
{
    public List<string> ListCharacterPointGuid = new ();
    public List<CharacterData> ListCharacterPointData = new ();
    public List<Character> ListCharacterPointRuntime = new ();
    public List<CharacterEntity> ListCharacterPointEntity = new ();

    public List<string> ListCharacterAssistGuid = new ();
    public List<CharacterData> ListCharacterAssistData = new ();
    public List<Character> ListCharacterAssistRuntime = new ();
    public List<CharacterEntity> ListCharacterAssistEntity = new ();

    public TeamComponentCharacter(TeamData data) 
    {

    }
}
