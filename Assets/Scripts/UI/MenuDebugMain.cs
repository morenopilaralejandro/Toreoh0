public class MenuDebugMain : Menu
{
    protected override void Start() 
    {
        base.Start();
        menuManager.OpenMenu(this);
    }

    public void OnButtonTestClicked() 
    {
        CustomLog.Error("test");
    }

    public void OnButtonWorldClicked() 
    {
        PersistenceEvents.RaiseNewGameStarted();
        SceneLoaderManager.Instance.UnloadGroup("SceneGroupData-DebugMainMenu");
        SceneLoaderManager.Instance.LoadGroup("SceneGroupData-World");
    }
}
