public class SelectorDialogChoiceAction : ISelectorActionClick<DialogSerializableChoice>
{
    public void Execute(DialogSerializableChoice obj, IMenuClosable menu)
    {
        DialogEvents.RaiseChoiceSelected(obj.ChoiceIndex);
    }
}
