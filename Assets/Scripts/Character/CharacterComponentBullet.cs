public class CharacterComponentBullet
{
    public float RadiusHit;
    public float RadiusGrace;
    public float RadiusVisual;

    public float RadiusHitSqr;
    public float RadiusGraceSqr;

    public CharacterComponentBullet(CharacterData data, Character character)
    {
        RadiusHit = character.CharacterComponentConfig.Config.RadiusHit;
        RadiusGrace = character.CharacterComponentConfig.Config.RadiusGrace;
        RadiusVisual = character.CharacterComponentConfig.Config.RadiusVisual;

        RadiusHitSqr = RadiusHit * RadiusHit;
        RadiusGraceSqr = RadiusGrace * RadiusGrace;
    }
}
