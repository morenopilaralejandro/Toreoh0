public class SelectorDialogChoiceActionClick : ISelectorActionClick<DialogSerializableChoice>
{
    public void Execute(DialogSerializableChoice obj, IMenuClosable menu)
    {
        DialogEvents.RaiseChoiceSelected(obj.ChoiceIndex);
    }
}
