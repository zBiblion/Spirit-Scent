using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerSideScrollerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float groundCheckDistance = 0.25f;
    [SerializeField] private LayerMask groundLayers = ~0;

    private Rigidbody rb;
    private Collider playerCollider;
    private float startZ;
    private bool jumpQueued;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        startZ = transform.position.z;

        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpQueued = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = -Input.GetAxisRaw("Horizontal");
        Vector3 velocity = rb.linearVelocity;
        velocity.x = horizontal * moveSpeed;
        velocity.z = 0f;
        rb.linearVelocity = velocity;

        Vector3 position = rb.position;
        position.z = startZ;
        rb.position = position;

        if (jumpQueued)
        {
            jumpQueued = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, 0f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Bounds bounds = playerCollider.bounds;
        Vector3 origin = new Vector3(bounds.center.x, bounds.min.y + 0.05f, bounds.center.z);
        float radius = Mathf.Max(0.05f, Mathf.Min(bounds.extents.x, bounds.extents.z) * 0.85f);
        float distance = groundCheckDistance + 0.08f;

        return Physics.SphereCast(origin, radius, Vector3.down, out _, distance, groundLayers, QueryTriggerInteraction.Ignore);
    }
}
