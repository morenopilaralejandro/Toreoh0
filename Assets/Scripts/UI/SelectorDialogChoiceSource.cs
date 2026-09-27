public SelectorDialogChoiceSource : ISelectorSource<DialogSerializableChoice>
{
    private List<DialogSerializableChoice> choices;
    
    public SelectorDialogChoiceSource(List<DialogSerializableChoice> choices) 
    {
        this.choices = choices;
    }

    public IEnumerable<DialogSerializableChoice> Enumerate() => choices;
}
