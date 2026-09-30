using UnityEngine;
using TMPro;

public class SelectorDialogChoiceListItem : SelectorListItem<DialogSerializableChoice>
{
    [SerializeField] private TMP_Text textChoice;

    public override void SetData(DialogSerializableChoice data)
    {
        textChoice.text = data.TextResolved;
    }

    public override void Clear()
    {
        textChoice.text = string.Empty;
    }
}
