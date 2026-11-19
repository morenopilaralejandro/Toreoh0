using System;
using System.Collections.Generic;
using Aremoreno.Enums.Character;

public class CharacterComponentStatusEffectVolatile
{
    public HashSet<StatusEffectVolatile> HashSetStatus = new ();
    public event Action<StatusEffectVolatile> OnStatusApplied;
    public event Action<StatusEffectVolatile> OnStatusCleared;

    public CharacterComponentStatusEffectVolatile() { }

    public void ClearStatus(StatusEffectVolatile status) 
    {
        if (!HasStatus(status)) return;
        HashSetStatus.Remove(status);
        OnStatusCleared?.Invoke(status);
    }

    public void ClearAllStatus() 
    {
        foreach(var status in HashSetStatus)
            ClearStatus(status);
    }

    public void ApplyStatus(StatusEffectVolatile status) 
    {
        ClearStatus(status);
        HashSetStatus.Add(status);
        OnStatusApplied?.Invoke(status);
    }

    // api
    public bool HasStatus(StatusEffectVolatile status) => HashSetStatus.Contains(status);
    public bool IsStunned => HasStatus(StatusEffectVolatile.Stunned);
    public void ClearStun() => ClearStatus(StatusEffectVolatile.Stunned);
}
