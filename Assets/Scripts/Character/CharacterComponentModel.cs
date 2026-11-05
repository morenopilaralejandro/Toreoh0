using UnityEngine;

public class CharacterComponentModel : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private float speedRotation;
    public Transform Model => model;
    public float SpeedRotation => speedRotation;

    public void SetSpeedRotation(float speedRotation) => this.speedRotation = speedRotation;

    public void Rotate(Quaternion directionRotation)
    {
        model.rotation  = Quaternion.Slerp(
            model.rotation,
            directionRotation,
            speedRotation * Time.fixedDeltaTime
        );
    }

    public void Rotate(Vector3 directionMove)
    {
        model.rotation  = Quaternion.Slerp(
            model.rotation,
            Quaternion.LookRotation(directionMove),
            speedRotation * Time.fixedDeltaTime
        );
    }

    public void Rotate(Vector3 directionMove, float speedRotation)
    {
        model.rotation  = Quaternion.Slerp(
            model.rotation,
            Quaternion.LookRotation(directionMove),
            speedRotation * Time.fixedDeltaTime
        );
    }
}
