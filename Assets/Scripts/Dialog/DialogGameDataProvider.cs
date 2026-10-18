using Ink.Runtime;

public class DialogGameDataProvider
{
    // field
    private DialogLocalizationBridge localizationBridge;
    private AudioManager audioManager;
    private StoryManager storyManager;

    private Shop shop;

    // constructor
    public DialogGameDataProvider(DialogLocalizationBridge localizationBridge) 
    {
        this.localizationBridge = localizationBridge;
        audioManager = AudioManager.Instance;
        storyManager = StoryManager.Instance;
    }

    // helper
    private void TryCacheShop(string shopId)
    {
        if (shop != null && shop.AttributesComponent.ShopId == shopId) return;
        if (string.IsNullOrEmpty(shopId))
            shop = null;    
        else
            shop = ShopFactory.CreateById(shopId);
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
            case "buy":
                TryCacheShop(contextId);
                UIEvents.RaiseSelectorItemShopOpenRequested(
                    new SelectorItemShopSource(shop), 
                    new SelectorItemShopActionClickBuy(shop),
                    null);
                break;
            case "sell":
                TryCacheShop(contextId);
                UIEvents.RaiseSelectorItemStorageSlotBagOpenRequested(
                    null, 
                    new SelectorItemStorageSlotBagActionClickSell(shop),
                    null);
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
