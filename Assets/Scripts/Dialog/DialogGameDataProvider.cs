using Ink.Runtime;

public class DialogGameDataProvider
{
    // field
    private DialogLocalizationBridge localizationBridge;
    private AudioManager audioManager;
    private StoryManager storyManager;

    // constructor
    public DialogGameDataProvider(DialogLocalizationBridge localizationBridge) 
    {
        this.localizationBridge = localizationBridge;
        audioManager = AudioManager.Instance;
        storyManager = StoryManager.Instance;
    }

    // functions
    //public string GetHeroName() => "hero name";
    public void PlaySfx(string sfxId) => _ = audioManager.Sfx.Play(sfxId);
    public void ClearArguments() => localizationBridge.ClearArguments();
    public void SetCurrentChestItemAsArgument() => 
        localizationBridge.SetArgument(
            "chestItemName", 
            localizationBridge.ResolveItemName(
                storyManager.ChestTracker.CurrentOpeningChestId
            )
        );

    public void OpenSubmenu(string menuId, string contextId) 
    {
        switch(menuId) 
        {
            case "test":
                UIEvents.RaiseMenuTestOpenRequested();
                break;
        }
    }

    // Story
    // get flag
    // set flag
    // get variable
    // set variable
    
    // bind
    public void BindExternalFunctions(Story story) 
    {
        story.BindExternalFunction("PlaySfx", (string sfxId) => { PlaySfx(sfxId); });
        story.BindExternalFunction("ClearArguments", () => { ClearArguments(); });
        story.BindExternalFunction("SetCurrentChestItemAsArgument", () => { SetCurrentChestItemAsArgument(); });
        story.BindExternalFunction("OpenSubmenu", (string menuId, string contextId) => { OpenSubmenu(menuId, contextId); });


        /*
        story.BindExternalFunction("OpenSubmenuShop", (string id) =>
        {
            return localizationBridge.ResolveItemName(id);
        });
        */
    }
}
