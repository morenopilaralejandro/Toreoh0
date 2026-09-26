using Ink.Runtime;

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


        story.BindExternalFunction("GetCurrentChestItemName", (string id)) =>
        {
            // world manager chest system get current chest item -> set before chest dialog
            return localizationBridge.ResolveItemName(id);
        };

        story.BindExternalFunction("OpenSubmenuShop", (string id)) =>
        {
            return localizationBridge.ResolveItemName(id);
        };
        */
    }

    // SyncVariablesFromGameState
    public void SyncVariablesFromGameState(Story story) 
    {
        story.variablesState["heroName"] = GetHeroName();
    }
}
