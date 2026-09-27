using Ink.Runtime;
using System.Collections.Generic;
using Aremoreno.Enums.Dialog;

public class DialogManagerInkStory
{
    private Dictionary<string, Story> storyDict = new();
    private DialogConfig config;
    private DialogGameDataProvider gameDataProvider;
    private DialogLocalizationBridge localizationBridge;
    private DialogCacheSpeaker speakerCache;
    private Story currentStory;
    private List<DialogSerializableChoice> choices;
    public DialogStateMachine StateMachine { get; private set; }

    public void Initialize(
        DialogConfig config, 
        DialogGameDataProvider gameDataProvider, 
        DialogLocalizationBridge localizationBridge,
        DialogCacheSpeaker speakerCache) 
    {
        this.config = config;
        this.gameDataProvider = gameDataProvider;
        this.localizationBridge = localizationBridge;
        this.speakerCache = speakerCache;
        StateMachine = new DialogStateMachine();
    }

    private void BuildDict()
    {
        foreach (var mapping in config.StoryMappings) 
        {
            var story = new Story(mapping.InkStoryJson.text);
            gameDataProvider.BindExternalFunctions(story);
            storyDict[mapping.InkStoryId] = story;
        }
    }

    public void StartDialog(string storyId, string knotName)
    {
        currentStory = storyDict[storyId];
        currentStory.ChoosePathString(knotName);
        StateMachine.SetState(DialogState.WaitingForContinue);
        ContinueDialog();
    }

    private void ContinueDialog() 
    {
        if (StateMachine.State != DialogState.WaitingForContinue)
        StateMachine.SetState(DialogState.Processing);
        if (currentStory.canContinue) 
        {
            string text = currentStory.Continue();
            var tags = currentStory.currentTags;
            var line = DialogTagParser.ParseLine(text, tags);
            line.TextResolved = localizationBridge.ResolveDialogText(line);
            speakerCache.CacheCurrentSpeaker(line.SpeakerData);
            StateMachine.SetState(DialogState.WaitingForContinue);
            DialogEvents.RaiseLineReady(line, speakerCache.CurrentSpeaker);
        }
        else if (HasChoices)
        {
            PresentChoices();
        }
        else 
        {
            EndDialog();
        }
    }

    private bool HasChoices => currentStory.currentChoices.Count > 0;

    private void PresentChoices() 
    {
        StateMachine.SetState(DialogState.Processing);
        choices.Clear();
        for (int i = 0; i < currentStory.currentChoices.Count; i++)
        {
            var choiceInk = currentStory.currentChoices[i];
            var choiceTags = choiceInk.tags;
            var choiceParsed = DialogTagParser.ParseChoice(choiceInk.text, choiceTags);
            choiceParsed.TextResolved = localizationBridge.ResolveChoiceText(choiceParsed);
            choices.Add(choiceParsed);
        }
        StateMachine.SetState(DialogState.WaitingForChoice);
        DialogEvents.RaiseChoicesReady(choices);
    }

    private void SelectChoice(int choiceIndex)
    {
        if (StateMachine.State != DialogState.WaitingForChoice) return;
        StateMachine.SetState(DialogState.Processing);
        currentStory.ChooseChoiceIndex(choiceIndex);
        StateMachine.SetState(DialogState.WaitingForContinue);
        ContinueDialog();
    }

    public void EndDialog() 
    {
        DialogEvents.RaiseDialogEnded();
    }

    // persistence
    public List<InkStorySaveData> Export() 
    {
        List<InkStorySaveData> list = new (); 
        foreach (var kvp in storyDict)
        {
            InkStorySaveData inkStorySaveData = new InkStorySaveData 
            {
                InkStoryId = kvp.Key,
                InkStoryStateJson = kvp.Value.state.ToJson()
            };
            list.Add(inkStorySaveData);
        }
        return list;
    }

    public void Import(DialogManagerSaveData saveData)
    {
        BuildDict();
        foreach (var inkStorySaveData in saveData.InkStorySaveDataList)
            storyDict[inkStorySaveData.InkStoryId].state.LoadJson(inkStorySaveData.InkStoryStateJson);
    }

    public void Clear() 
    {
        BuildDict();
    }

    // event
    public void Subscribe() 
    {
        DialogEvents.OnChoiceSelected += OnChoiceSelected;
        DialogEvents.OnContinueRequested += OnContinueRequested;
    }

    public void Unsubscribe() 
    {
        DialogEvents.OnChoiceSelected -= OnChoiceSelected;
        DialogEvents.OnContinueRequested -= OnContinueRequested;
    }

    private void OnChoiceSelected(int choiceIndex) => SelectChoice(choiceIndex);
    private void OnContinueRequested() => ContinueDialog();
}
