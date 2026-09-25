public class DialogViewedTracker
{
    private HashSet<string> viewedDialogsHashSet;
    
    public void MarkAsViewed(string dialogId) => viewedDialogsHashSet.Add(dialogId);
    public void HasViewed(string dialogId) => viewedDialogsHashSet.Contains(dialogId)

    public void Clear()
    {
        viewedDialogsHashSet.Clear();
    }

    public void Import(DialogManagerSaveData saveData)
    {
        viewedDialogsHashSet = new HashSet<string>(saveData.ViewedDialogsList);
    }

    public List<string> Export() 
    {
        return PersistenceParser.ParseHashset<string>(viewedDialogsHashSet);
    }
}
