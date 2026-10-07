using UnityEngine;
using Aremoreno.Enums.Animation;

public class CharacterEntityWorld : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;

    private void Update() 
    {
        rb.linearVelocity = InputManager.Instance.MapBattle.Move * 20f;
    }

    public void Teleport(Vector3 pos)
    {
        rb.position = pos;
        WorldEvents.RaiseCharacterTeleported(pos);
    }

    public void SetFacing(CharacterDirection direction)
    {
        
    }

}
