public class SelectorDialogChoiceListItem : SelectorListItem<DialogSerializableChoice>
{
    [SerializeField] private TMP_Text textChoice;

    protected override void OnBind(DialogSerializableChoice obj)
    {
        textChoice.text = obj.TextResolved;
    }

    protected override void OnUnbind(DialogSerializableChoice obj)
    {
        textChoice.text = string.Empty;
    }
}
