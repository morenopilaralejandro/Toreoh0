using UnityEngine;
using System.Collections.Generic;
using Aremoreno.Enums.Character;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string CharacterId;
    public List<Element> ListElement;
}
