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

    public static event Action OnDialogMenuClosed;
    public static void RaiseDialogMenuClose()
        => OnDialogMenuClosed.Invoke();

    // Story
    public static event Action<DialogSerializableLine> OnLineReady;
    public static void RaiseLineReady(DialogSerializableLine line)
        => OnLineReady.Invoke(line);

    public static event Action<List<DialogSerializableChoice>> OnChoicesReady;
    public static void RaiseChoicesReady(List<DialogSerializableChoice> choices)
        => OnChoicesReady.Invoke(choices);

    public static event Action OnDialogCompleted;
    public static void RaiseDialogCompleted()
        => OnDialogCompleted.Invoke();
}
