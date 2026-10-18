using System;

namespace Aremoreno.Enums.UI
{
    public enum MenuPlaceholder
    {
        Moving,
        Replacing
    }

    [Flags]
    public enum FeedbackAudioFlag 
    {
        None = 0,
        PointerEnter = 1 << 0,
        PointerExit = 1 << 1,
        PointerDown = 1 << 2,
        PointerUp = 1 << 3,
        Click = 1 << 4,
        BeginDrag = 1 << 5,
        EndDrag = 1 << 6,
        Drop = 1 << 7,
        Select = 1 << 8,
        Submit = 1 << 9
    }

    public enum BagMode 
    {
        Default,
        Sell
    }

    public enum AmountPickerMode 
    {
        Buy,
        Sell
    }
}
