using UnityEngine;
using Aremoreno.Enums.Animation;

public class CharacterEntityWorld : MonoBehaviour 
{
    private Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        rb.linearVelocity = InputManager.Instance.MapBattle.Move * 5f;
    }

    public void Teleport(Vector3 pos) 
    {
        rb.position = pos;
    }

    public void SetFacing(CharacterDirection direction)
    {
        
    }

}
