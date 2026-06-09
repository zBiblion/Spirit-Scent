using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 3f;
    public float moveDistance = 5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * moveDistance;
        transform.position = new Vector3(startPosition.x + offset,
                                         startPosition.y,
                                         startPosition.z);
    }
}