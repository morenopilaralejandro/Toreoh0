using Ink.Runtime;

public class DialogGameDataProvider
{
    private DialogLocalizationBridge localizationBridge;
    private AudioManager audioManager;

    // constructort
    public DialogGameDataProvider(DialogLocalizationBridge localizationBridge) 
    {
        this.localizationBridge = localizationBridge;
        audioManager = AudioManager.Instance;
    }

    // functions
    //public string GetHeroName() => "hero name";
    public void PlaySfx(string sfxId) => _ = audioManager.Sfx.Play(sfxId);
    public void SetCurrentChestItemAsArgument() => localizationBridge.SetArgument("chestItemName", localizationBridge.ResolveItemName("item-00000-test"));
    //TODO get item from chest manager

    public void OpenSubmenuTest(string id) 
    {
        
    }

    // Story
    // get flag
    // set flag
    // get variable
    // set variable
    
    // BindExternalFunction
    public void BindExternalFunctions(Story story) 
    {
        story.BindExternalFunction("PlaySfx", (string sfxId) => { PlaySfx(sfxId); });
        story.BindExternalFunction("SetCurrentChestItemAsArgument", () => { SetCurrentChestItemAsArgument(); });
        story.BindExternalFunction("OpenSubmenuTest", (string id) => { OpenSubmenuTest(id); });


        /*
        story.BindExternalFunction("OpenSubmenuShop", (string id) =>
        {
            return localizationBridge.ResolveItemName(id);
        });
        */
    }
}
