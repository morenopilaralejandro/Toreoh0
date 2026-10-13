using Ink.Runtime;

public class DialogInkStoryInkStoryComponentVariables
{
    private DialogConfig config;
    private DialogGameDataProvider gameDataProvider;
    private DialogLocalizationBridge localizationBridge;

    private string heroName;

    public void Initialize(
        DialogConfig config, 
        DialogGameDataProvider gameDataProvider, 
        DialogLocalizationBridge localizationBridge) 
    {
        this.config = config;
        this.gameDataProvider = gameDataProvider;
        this.localizationBridge = localizationBridge;
        CacheVariables();
    }

    private void CacheVariables() 
    {
        //heroName = gameDataProvider.GetHeroName();
    }

    // set
    public void SetInkVariable(Story story, string variableName, object val) 
    {
        story.variablesState[variableName] = val;
        localizationBridge.SetArgument(variableName, val.ToString());
    }

    // Sync
    public void SyncFromGameState(Story story) 
    {
        story.variablesState["heroName"] = heroName;
    }

    public void SyncLocalization(Story story) 
    {
        foreach (string variableName in story.variablesState)
            localizationBridge.SetArgument(variableName, story.variablesState[variableName].ToString());
    }
}
