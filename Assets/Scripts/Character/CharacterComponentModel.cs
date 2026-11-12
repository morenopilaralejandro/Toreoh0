using UnityEngine;

public class CharacterComponentModel : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private float speedRotation;
    [SerializeField] private Vector3 upwards = Vector3.up;
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
            Quaternion.LookRotation(directionMove, upwards),
            speedRotation * Time.fixedDeltaTime
        );
    }

    public void RotateInstant(Vector3 directionMove)
    {
        model.rotation  = Quaternion.LookRotation(directionMove, upwards);
    }

    public void Rotate(Vector3 directionMove, float speedRotation)
    {
        model.rotation  = Quaternion.Slerp(
            model.rotation,
            Quaternion.LookRotation(directionMove, upwards),
            speedRotation * Time.fixedDeltaTime
        );
    }

    public void SetRotation(Quaternion rot)
    {
        model.rotation  = rot;
    }
}
