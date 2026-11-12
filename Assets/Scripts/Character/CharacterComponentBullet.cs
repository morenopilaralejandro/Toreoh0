public class CharacterComponentBullet
{
    public float RadiusHit;
    public float RadiusGrace;
    public float RadiusVisual;

    public float RadiusHitSqr;
    public float RadiusGraceSqr;

    public CharacterComponentBullet(CharacterData data) 
    {
        RadiusHit = 0.55f;
        RadiusGrace = 0.8f;
        RadiusVisual = 0.8f;

        RadiusHitSqr = RadiusHit * RadiusHit;
        RadiusGraceSqr = RadiusGrace * RadiusGrace;
    }
}
