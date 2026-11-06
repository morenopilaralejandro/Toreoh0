using System.Collections.Generic;

public class TeamComponentCharacter
{
    public List<string> ListCharacterPointGuid = new ();
    //public List<CharacterData> ListCharacterPointData = new ();
    public List<Character> ListCharacterPointRuntime = new ();
    public List<CharacterEntityBattle> ListCharacterPointEntity = new ();

    public List<string> ListCharacterAssistGuid = new ();
    //public List<CharacterData> ListCharacterAssistData = new ();
    public List<Character> ListCharacterAssistRuntime = new ();
    public List<CharacterEntityBattle> ListCharacterAssistEntity = new ();

    public TeamComponentCharacter(TeamData data) 
    {
        if(!string.IsNullOrWhiteSpace(data.CharacterPointId0)) 
        {
            ListCharacterPointRuntime.Add(CharacterFactory.CreateById(data.CharacterPointId0));
        }

        if(!string.IsNullOrWhiteSpace(data.CharacterPointId1)) 
        {
            ListCharacterPointRuntime.Add(CharacterFactory.CreateById(data.CharacterPointId1));
        }


        if(!string.IsNullOrWhiteSpace(data.CharacterAssistId0)) 
        {
            ListCharacterAssistRuntime.Add(CharacterFactory.CreateById(data.CharacterAssistId0));
        }

        if(!string.IsNullOrWhiteSpace(data.CharacterAssistId1)) 
        {
            ListCharacterAssistRuntime.Add(CharacterFactory.CreateById(data.CharacterAssistId1));
        }
    }

    public void InitializeForBattle() 
    {
        ListCharacterPointEntity.Clear();
        ListCharacterAssistEntity.Clear();
    }
}
