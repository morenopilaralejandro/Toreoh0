using UnityEngine;

public class CharacterComponentRigidbody : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 eulerAngleVelocity;
    [SerializeField] private float speedRotation;
    [SerializeField] private float speedMovement;
    [SerializeField] private float acceleration;
    public Rigidbody Rb => rb;
    public float SpeedRotation => speedRotation;
    public float SpeedMovement => speedMovement;
    public float Acceleration => acceleration;

    // position
    public void MovePosition(Vector3 moveDirection)
    {
        rb.MovePosition(rb.transform.position + moveDirection * speedMovement * Time.fixedDeltaTime);
    }

    public void MovePosition(Vector3 moveDirection, float speedMovement)
    {
        rb.MovePosition(rb.transform.position + moveDirection * speedMovement * Time.fixedDeltaTime);
    }

    public void Teleport(Vector3 pos)
    {
        rb.linearVelocity = Vector2.zero;
        rb.position = pos;
        transform.position = pos;
    }

    public void SetSpeedMovement(float speedMovement) => this.speedMovement = speedMovement;

    // rotation
    public void MoveRotation() 
    {
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void MoveRotation(Vector3 eulerAngleVelocity, float rotationSpeed) 
    {
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void SetEulerAngleVelocity(Vector3 eulerAngleVelocity) => this.eulerAngleVelocity = eulerAngleVelocity;
    public void SetSpeedRotation(float speedRotation) => this.speedRotation = speedRotation;

    // force
    public void AddForce(Vector3 force, ForceMode mode = ForceMode.Acceleration) 
    {
        rb.AddForce(force, mode);
    }

    public void AddForce(Vector3 force, float acceleration, ForceMode mode = ForceMode.Acceleration) 
    {
        rb.AddForce(force * acceleration, mode);
    }

    public void AddForce(Vector3 force, float speedMovement, float acceleration, ForceMode mode = ForceMode.Acceleration) 
    {
        rb.AddForce(force * speedMovement * acceleration, mode);
    }
}
