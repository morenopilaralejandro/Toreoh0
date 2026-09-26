using System;
using System.Collections.Generic;
using Aremoreno.Enums.Dialog;

public static class DialogEvents 
{
    // Manager
    public static event Action OnDialogStarted;
    public static void RaiseDialogStarted()
        => OnDialogStarted.Invoke();

    public static event Action OnDialogEnded;
    public static void RaiseDialogEnded()
        => OnDialogEnded.Invoke();

    public static event Action OnDialogCompleted;
    public static void RaiseDialogCompleted()
        => OnDialogCompleted.Invoke();

    public static event Action OnDialogCanceled;
    public static void RaiseDialogCanceled()
        => OnDialogCanceled.Invoke();

    // UI
    public static event Action OnTextDisplayComplete;
    public static void RaiseTextDisplayComplete()
        => OnTextDisplayComplete.Invoke();

    public static event Action<int> OnChoiceSelected;
    public static void RaiseChoiceSelected(int choiceIndex)
        => OnChoiceSelected.Invoke(choiceIndex);

    public static event Action OnContinueRequested;
    public static void RaiseContinueRequested()
        => OnContinueRequested.Invoke();

    public static event Action OnDialogSubMenuClosed;
    public static void RaiseDialogSubMenuClose()
        => OnDialogSubMenuClosed.Invoke();

    // Story
    public static event Action<DialogSerializableLine, Speaker> OnLineReady;
    public static void RaiseLineReady(DialogSerializableLine line, Speaker speaker)
        => OnLineReady.Invoke(line, speaker);

    public static event Action<List<DialogSerializableChoice>> OnChoicesReady;
    public static void RaiseChoicesReady(List<DialogSerializableChoice> choices)
        => OnChoicesReady.Invoke(choices);
}
