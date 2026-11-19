using Aremoreno.Enums.Character;

public class CharacterComponentStatusEffectBattle
{
    private CharacterEntityBattle entity;

    public CharacterComponentStatusEffectBattle(CharacterEntityBattle entity)
    {
        this.entity = entity;
    }

    // event
    public void Subscribe() 
    {
        this.entity.Character.CharacterComponentStatusEffectVolatile.OnStatusApplied += OnStatusVolatileApplied;
        this.entity.Character.CharacterComponentStatusEffectVolatile.OnStatusCleared += OnStatusVolatileCleared;
        this.entity.Character.CharacterComponentStatusEffectPermanent.OnStatusApplied += OnStatusPermanentApplied;
        this.entity.Character.CharacterComponentStatusEffectPermanent.OnStatusCleared += OnStatusPermanentCleared;
    }

    public void Unsubscribe() 
    {
        this.entity.Character.CharacterComponentStatusEffectVolatile.OnStatusApplied -= OnStatusVolatileApplied;
        this.entity.Character.CharacterComponentStatusEffectVolatile.OnStatusCleared -= OnStatusVolatileCleared;
        this.entity.Character.CharacterComponentStatusEffectPermanent.OnStatusApplied -= OnStatusPermanentApplied;
        this.entity.Character.CharacterComponentStatusEffectPermanent.OnStatusCleared -= OnStatusPermanentCleared;
    }

    private void OnStatusVolatileApplied(StatusEffectVolatile status) 
    {
        switch(status)
        {
            case StatusEffectVolatile.Stunned:
                break;
        }
    }

    private void OnStatusVolatileCleared(StatusEffectVolatile status) 
    {
        switch(status)
        {
            case StatusEffectVolatile.Stunned:
                break;
        } 
    }

    private void OnStatusPermanentApplied(StatusEffectPermanent status) 
    {
        switch(status)
        {
            case StatusEffectPermanent.Fainted:
                break;
        }
    }

    private void OnStatusPermanentCleared(StatusEffectPermanent status) 
    {
        switch(status)
        {
            case StatusEffectPermanent.Fainted:
                break;
        }
    }
}
