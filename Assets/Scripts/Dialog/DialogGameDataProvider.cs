public class DialogGameDataProvider
{
    private DialogLocalizationBridge localizationBridge;

    // variables
    private string heroName; 

    // constructort
    public DialogGameDataProvider() 
    {
        // TODO pass managers
    }

    // functions
    public string GetHeroName() 
    {
        return "hero name";
    }

    // Story
    // get flag
    // set flag
    // get variable
    // set variable
    
    // BindExternalFunction
    public void BindExternalFunctions(Story story) 
    {
        /*
        story.BindExternalFunction("GetItemName", (string id)) =>
        {
            return localizationBridge.ResolveItemName(id);
        };
        */
    }

    // SyncVariablesFromGameState
    private void SyncVariablesFromGameState(Story story) 
    {
        story.variablesState["heroName"] = GetHeroName();
    }
}
