using UnityEngine;
using System;
using System.Collections.Generic;

public class InputStateTracker<T> where T : Enum
{
    private Dictionary<T, ButtonState> buttons;
    private int buttonCount;
    
    public event Action<T> OnButtonDown;
    public event Action<T> OnButtonUp;

    public InputStateTracker() 
    {
        buttons = new Dictionary<T, ButtonState>();
        buttonCount = EnumUtils.GetLength<T>();
        foreach (T input in EnumUtils.GetValues<T>())
            buttons[input] = new ButtonState();
    }

    public void Update() 
    {
        foreach (var input in buttons.Keys)
        {
            var button = buttons[input];
            button.UpdateHoldTime();
            buttons[input] = button;
        }
    }

    public void RecordButtonDown(T input, float bufferDuration = 0f)
    {
        if (!buttons.TryGetValue(input, out var button)) return;
        button.RecordPress(bufferDuration);
        buttons[input] = button;
        OnButtonDown?.Invoke(input);
    }


    public void RecordButtonUp(T input) 
    {
        if (!buttons.TryGetValue(input, out var button)) return;
        button.RecordRelease();
        buttons[input] = button;
        OnButtonUp?.Invoke(input);
    }

    public bool GetDown(T input) =>
        buttons.TryGetValue(input, out var button) &&
        button.WasPressedThisFrame;

    public bool GetHeld(T input) =>
        buttons.TryGetValue(input, out var button) &&
        button.IsHeld;

    public bool GetUp(T input) =>
        buttons.TryGetValue(input, out var button) &&
        button.WasRelasedThisFrame;

    public float GetHoldTime(T input) =>
        buttons.TryGetValue(input, out var button) ? button.HoldTime : 0f;

    public bool GetHeldForDuration(T input, float duration) =>
        buttons.TryGetValue(input, out var button) &&
        button.IsHeldForDuration(duration);

    public bool ConsumeBuffered(T input, out bool wasBuffered)
    {
        wasBuffered = false;
        if (!buttons.TryGetValue(input, out var button)) return false;
        if (button.TryConsumeBuffered(out wasBuffered))
        {
            buttons[input] = button;
            return true;
        }
        return false;
    }

    public void InvalidateAllBuffers() 
    {
        foreach (var input in buttons.Keys) 
        {
            var button = buttons[input];
            button.ClearBuffer();
            buttons[input] = button;
        }
    }

    public void InvalidateBuffer(T input)
    {
        if (buttons.TryGetValue(input, out var button))
        {
            button.ClearBuffer();
            buttons[input] = button;
        }
    }

    public int GetButtonCount() => buttonCount;
}
