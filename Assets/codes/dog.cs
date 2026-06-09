using UnityEngine;

public class dog : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset = new Vector3(0, 2f, -10f); // Adjust Y in the Inspector!
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return; // Prevent errors if target is missing

        // We use target position + our custom offset
        Vector3 targetPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}