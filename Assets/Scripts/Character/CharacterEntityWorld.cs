public class CharacterEntityWorld : MonoBehaviour 
{
    private Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>()
    }

    private void Update() 
    {
        rb.velocity = InputManager.Instance.MapBattle.Move = 5f;
    }
}
