using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Character;
using Aremoreno.Enums.Duel;
using Aremoreno.Enums.Move;

public class BattleComponentDamageCalculator
{
    private Battle battle;

    private const float STAT_MULTIPLIER_MAIN = 0.5f;
    //private const float STAT_MULTIPLIER_SUB = 0.25f;
    private const float MULTIPLIER_DEFAULT = 1f;
    private const float SPECIAL_MULTIPLIER = 2f;
    private const float ELEMENT_MULTIPLIER_MATCH = 1.5f;
    private const float ELEMENT_MULTIPLIER_EFFECTIVE = 1.5f;
    private const float ELEMENT_MULTIPLIER_RESISTED = 0.5f;
    private const float DAMAGE_MIN = 0f;
    private const float DAMAGE_MAX = 999999f;
    private float floatValue;

    public BattleComponentDamageCalculator(Battle battle, BattleConfig battleConfig)
    {
        this.battle = battle;
    }

    public void ApplyDamage(
        CharacterEntityBattle defenseEntity, 
        Element moveElement, 
        MoveCategory moveCategory, 
        float damage)
    {
        damage -= CalcDefense(
            GetElementMultiplierEffective(moveElement, defenseEntity.Character.CharacterComponentElement.ListElement),
            defenseEntity.Character.CharacterComponentStats.GetStatValueByDuelRoleAndMoveCategory(DuelRole.Defense, moveCategory)
        );
        
        damage = ClampDamage(damage);
        //CustomLog.Warning($"[BattleComponentBullet] CharacterId: {defenseEntity.Character.CharacterComponentAttributes.CharacterId}. Damage: {damage}.");
        // TODO reduce hp by damage
    }

    public float CalcDamage(
        float damageBase, 
        float elementMultiplierMatch, 
        float elementMultiplierCommandType,
        float statMainValue)
    {
        floatValue = damageBase * elementMultiplierCommandType;
        floatValue += statMainValue * STAT_MULTIPLIER_MAIN;
        floatValue *= elementMultiplierMatch;
        return floatValue;
    }

    public float CalcDefense(
        float elementMultiplierEffective, 
        float statMainValue)
    {
        floatValue = statMainValue * STAT_MULTIPLIER_MAIN;
        floatValue *= elementMultiplierEffective;
        return floatValue;
    }

    public float ClampDamage(float damage)
    {
        return Mathf.Clamp(damage, DAMAGE_MIN, DAMAGE_MAX);
    }

    // element effective
    public bool IsElementEffective(Element offenseElement, Element defenseElement)
    {

        int offenseIndex = (int) offenseElement;
        int defenseIndex = (int) defenseElement;

        int nextIndex = (offenseIndex + 1) % EnumUtils.GetLength<Element>();
        if (nextIndex == 0) nextIndex++; // None is index 0

        return defenseIndex == nextIndex;
    }

    public float GetElementMultiplierEffective(Element offenseElement, List<Element> defenseElementList)
    {
        floatValue = MULTIPLIER_DEFAULT;
        foreach (Element defenseElement in defenseElementList) 
        {
            if (IsElementEffective(offenseElement, defenseElement))
                floatValue *= ELEMENT_MULTIPLIER_EFFECTIVE;
            else if (IsElementEffective(defenseElement, offenseElement))
                floatValue *= ELEMENT_MULTIPLIER_RESISTED;
        }
        return floatValue;
    }

    // element match
    // call when spawining patter bullet
    public float GetElementMultiplierMatch(CharacterEntityBattle entity, Element moveElement)
    {
        floatValue = MULTIPLIER_DEFAULT;
        if (entity.Character.CharacterComponentElement.Contains(moveElement))
            floatValue *= ELEMENT_MULTIPLIER_MATCH;
        return floatValue;
    }
        /*        
        if (wing match) multipliet + wing refimenet bonus
        else if bullet and character match multipliet
        else 1
        */

    // move command type
    public float GetElementMultiplierCommandType(MoveCommandType moveCommandType) 
    {
        floatValue = MULTIPLIER_DEFAULT;
        if (moveCommandType == MoveCommandType.Special)
            floatValue *= SPECIAL_MULTIPLIER;
        return floatValue;
    }
}
