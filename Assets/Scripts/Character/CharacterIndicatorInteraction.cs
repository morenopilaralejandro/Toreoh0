using UnityEngine;

public class CharacterIndicatorInteraction : MonoBehaviour
{
    [SerializeField] SpriteRenderer indicator;

    public void SetEnabled(bool isEnabled) => indicator.enabled = isEnabled;
}
