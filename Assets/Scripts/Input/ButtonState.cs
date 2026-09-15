using UnityEngine;

public struct ButtonState 
{
    public bool IsHeld { get; private set; }
    public float HoldTime { get; private set; }
    private uint pressedFrame;
    private uint releasedFrame;
    private double bufferExpiryTime;
    private bool hasConsumedBuffer;

    public void Reset() 
    {
        IsHeld = false;
        HoldTime = 0f;
        pressedFrame = 0;
        releasedFrame = 0;
        bufferExpiryTime = 0;
        hasConsumedBuffer = false;
    }

    public void RecordPress(float bufferDuration = 0f)
    {
        IsHeld = true;
        HoldTime = 0f;
        pressedFrame = (uint)Time.frameCount;
        hasConsumedBuffer = false;
        bufferExpiryTime = bufferDuration > 0f
            ? Time.unscaledTimeAsDouble + bufferDuration
            : 0;
    }

    public void RecordRelease()
    {
        IsHeld = false;
        releasedFrame = (uint)Time.frameCount;
    }

    public void UpdateHoldTime() 
    {
        if (IsHeld) HoldTime += Time.unscaledDeltaTime;
    }

    public bool WasPressedThisFrame => pressedFrame == (uint)Time.frameCount;
    public bool WasRelasedThisFrame => releasedFrame == (uint)Time.frameCount;
    public bool IsHeldForDuration(float duration) => HoldTime >= duration;
    public bool IsBuffered => !hasConsumedBuffer && Time.unscaledTimeAsDouble <= bufferExpiryTime;
    public float GetTimeSincePressedSeconds() => (float)(Time.unscaledTimeAsDouble - GetPressTime());
    public double GetPressTime() => 
        pressedFrame > 0
        ? Time.unscaledTimeAsDouble - (Time.frameCount - pressedFrame) * Time.unscaledDeltaTime
        : 0;

    public bool TryConsumeBuffered(out bool wasBuffered)
    {
        wasBuffered = false;

        if (WasPressedThisFrame) 
        {
            hasConsumedBuffer = true;
            return true;
        }

        if (IsBuffered)
        {
            wasBuffered = true;
            hasConsumedBuffer = true;
            return true;
        }

        return false;
    }

    public void ClearBuffer() 
    {
        bufferExpiryTime = 0;
        hasConsumedBuffer = false;
    }


}
