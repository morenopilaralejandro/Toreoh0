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
}
