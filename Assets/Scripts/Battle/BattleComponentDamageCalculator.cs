public class BattleComponentDamageCalculator
{
    private Battle battle;

    private const float STAT_MULTIPLIER_MAIN = 0.5f;
    //private const float STAT_MULTIPLIER_SUB = 0.25f;
    private const float ELEMENT_MULTIPLIER_MATCH = 1.5f;
    private const float ELEMENT_MULTIPLIER_EFFECTIVE = 1.5f;
    private const float ELEMENT_MULTIPLIER_RESISTED = 0.5f;
    

    public BattleComponentDamageCalculator(Battle battle, BattleConfig battleConfig)
    {
        this.battle = battle;

    }


    apply damage by bullet source
        offense enitit = team Component GetEntityByBulletSource
        ApplyDamage(offense, defense)

    how to now the bullet element melee or range, supper etc
        get the move index and give it to the bullet
        equipped move index GetMoveByBulletSource

    public ApplyDamage(Enitity offense, Enitity defense, bullet)
    {
        
    }


    // effective
    public bool IsElementEffective(Element offenseElement, Element defenseElement)
    {
        int offenseIndex = (int) offenseElement;
        int defenseIndex = (int) defenseElement;

        int nextIndex = (offenseIndex + 1) % EnumUtils.GetLength<Element>();
        if (nextIndex == 0) nextIndex++; // None is index 0

        return defenseIndex == nextIndex;
    }

    public float GetEffectiveMultiplier(Element offenseElement, List<Element> defenseElementList)
    {
        




        in this game only one element is effective againt another
        example -> fire agains a resist and a weekess

            agains a resist: 1 - 0,5 
            current value 0.5
            againt a weakens: 0.5 + 0.5
            final result 1

         againt resist and neutral
            - 0.5
            + 0

            againt a weakness and neutra
            + 0.5
            -0

if effective * 1,5 -> IsElementEffective
if resisted * 0,5 -> IsElementEffective reverse args
            
              


        for each defense elelemnt in list
            if is effective (offense, delfense elemen)
                1 *= ELEMENT_MULTIPLIER_EFFECTIVE
            else if effecti (defese, offense)
                1 *= ELEMENT_MULTIPLIER_RESISTED

        return 1
    }


}
