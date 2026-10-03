using Aremoreno.Enums.Animation;

public class SpawnPoint : MonoBehaviour
{
    public string SpawnPointId;
    public CharacterDirection FacingDirection;

    public Vector3 SpawnPosition => transform.position;

    private void OnDrawGizmos() 
    {
        GizmosUtils.DrawSphere(Color.green, transform.position, 0.3f)
        GizmosUtils.DrawRay(Color.blue, transform.position, (Vector3)CharacterDirectionUtils.EnumToVector2(FacingDirection) * 0.5f)
    }
}
