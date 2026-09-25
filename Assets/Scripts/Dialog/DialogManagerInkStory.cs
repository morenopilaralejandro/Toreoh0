public class DialogManagerInkStory
{
    private Dictionary<string, Story> storyDict = new();
    private DialogConfig config;
    private DialogGameDataProvider gameDataProvider;
    private Story currentStory;
    private List<DialogSerializableChoice> choices;

    public void Initialize() 
    {
        asd
    }

    private void BuildDict()
    {
        foreach (var mapping in config.StoryMappings) 
        {
            var story = new Story(mapping.InkStoryJson.text)
            gameDataProvider.BindExternalFunction(story);
            storyDict[mapping.InkStoryId] = story;
        }
    }

    public void StartDialog(string storyId, string knotName)
    {
        currentStory = storyDict[storyId];
        // state active
        // gameDataProvider.SyncVariablesFromGameState();
        currentStory.ChoosePathString(knotName);
        ContinueDialog();
    }

    public void ContinueDialog() 
    {
        // if state
        if (currentStory.canContinue) 
        {
            string text = currentStory.Continue();
            var tags = currentStory.currentTags;
            var line = DialogTagParser.ParseLine(text, tags);
            line.TextResolved = localizationBridge.ResolveDialogText(line);
            DialogEvents.RaiseLineReady(line);
        }
        else if () 
        {
            PresentChoices();
        }
        else 
        {
            EndDialog();
        }
    }

    public void PresentChoices() 
    {
        choices.Clear();
        for (int i = 0; i < currentStory.currentChoices.Count; i++)
        {
            var choiceInk = currentStory.currentChoices[i];
            var choiceTags = choiceInk.tags;
            var choiceParsed = DialogTagParser.ParseChoice(choiceInk.text, choiceTags);
            choice.TextResolved = localizationBridge.ResolveChoiceText(choiceParsed);
            choices.Add(choiceParsed);
        }
        DialogEvents.RaiseChoicesReady(choices);
    }

    public void SelectChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        if (currentStory.canContinue) Continue();
        ContinueDialog();
    }

    private void EndDialog() 
    {
        DialogEvents.RaiseDialogEnded();
    }

    public List<InkStorySaveData> Export() 
    {
        List<InkStorySaveData> list = new (); 
        foreach (var kvp in storyDict.Values)
        {
            InkStorySaveData inkStorySaveData = new InkStorySaveData 
            {
                InkStoryId = kvp.Key,
                InkStoryStateJson = kvp.Value.state.ToJson
            };
            list.Add(inkStorySaveData);
        }
        return list;
    }

    public void Import(DialogManagerSaveData saveData)
    {
        BuildDict();
            storyDict[inkStorySaveData.InkStoryId].state.LoadJson(inkStorySaveData.InkStoryStateJson);
    }

    public void Clear() 
    {
        BuildDict();
    }
}
