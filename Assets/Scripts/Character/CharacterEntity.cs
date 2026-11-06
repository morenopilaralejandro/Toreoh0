using UnityEngine;

public class CharacterEntity : MonoBehaviour
{
    public Character Character;

    public CharacterComponentRigidbody CharacterComponentRigidbody;
    public CharacterComponentModel CharacterComponentModel;

    public void Initialize(Character character)
    {
        Character = character;
    }
}
