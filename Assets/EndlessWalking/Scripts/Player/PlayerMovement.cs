using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour
{
    public float _movementSpeed = 5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);

        _rigidbody.velocity = direction * _movementSpeed;
    }
}
