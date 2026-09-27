public class SelectorDialogChoiceAction : ISelectorClickAction<DialogSerializableChoice>
{
    public void Execute(DialogSerializableChoice obj, IClosableMenu menu)
    {
        DialogEvents.RaiseChoiceSelected(obj.ChoiceIndex);
    }
}
