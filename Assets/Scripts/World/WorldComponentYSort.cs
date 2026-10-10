using System.Collections.Generic;

public class WorldComponentYSort 
{
    private List<YSort> list;

    public void Register(YSort ySort) => list.Add(ySort);
    public void Unregister(YSort ySort) => list.Remove(ySort);

    public void OnLateUpdateInternal() 
    {
        foreach(YSort obj in list) 
            obj.OnLateUpdateInternal();
    }
}
