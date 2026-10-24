public class MenuDebugMain : Menu
{
    protected override void Start() 
    {
        base.Start();
        menuManager.OpenMenu(this);
    }

    public void OnButtonWorldClicked()
    {
        PersistenceEvents.RaiseNewGameStarted();
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-World");
    }

    public void OnButtonMainClicked() => SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-MainMenu");
}
