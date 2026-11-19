using System;
using System.Collections.Generic;
using Aremoreno.Enums.Character;

public class CharacterComponentStatusEffectPermanent
{
    public HashSet<StatusEffectPermanent> HashSetStatus = new ();
    public event Action<StatusEffectPermanent> OnStatusApplied;
    public event Action<StatusEffectPermanent> OnStatusCleared;

    public CharacterComponentStatusEffectPermanent() { }

    public void ClearStatus(StatusEffectPermanent status) 
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

    public void ApplyStatus(StatusEffectPermanent status) 
    {
        ClearStatus(status);
        HashSetStatus.Add(status);
        OnStatusApplied?.Invoke(status);
    }

    // api
    public bool HasStatus(StatusEffectPermanent status) => HashSetStatus.Contains(status);
    public bool IsFainted => HasStatus(StatusEffectPermanent.Fainted);
}
