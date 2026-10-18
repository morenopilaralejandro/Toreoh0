using UnityEditor;

public class OverworldZonePopulator : Editor
{
    // TODO unused
    /*
    logic 
    {
        string[] overworldGuids = EditorUtils.FindAssets("t:OverworldData");
        string[] zoneGuids = EditorUtils.FindAssets("t:ZoneData");
        List<ZoneData> zoneList = new ();
        foreach (string guid in zoneGuids) 
            zoneList.Add(Editor.LoadAssetAtPath<ZoneData>(EditorUtils.GetAssetPath(guid)));

        foreach (string guid in overworldGuids) 
        {
            string path = EditorUtils.GetAssetPath(guid);
            OverworldData overworldData = Editor.LoadAssetAtPath<OverworldData>(path);
            overworld.Zones = zoneList;   
        }

        EditorUtils.SaveAssets();
        EditorUtils.Refresh();
    }
    */
}
