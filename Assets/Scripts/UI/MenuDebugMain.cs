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

    public void OnButtonBattleClicked()
    {
        BattleArgs.SetForTest();
        SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-Battle");
    }

    public void OnButtonMainClicked() => SceneLoaderManager.Instance.ReplaceGroup("SceneGroupData-MainMenu");
}
