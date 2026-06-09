using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PressureButton : MonoBehaviour
{
    [Header("Activator")]
    [SerializeField] private string targetTag = "Player";
    [SerializeField] private string targetObjectName = "Player";

    [Header("Receiver Movement")]
    [SerializeField] private Transform receiver;
    [SerializeField] private float riseHeight = 50f;
    [SerializeField] private float moveSpeed = 57f;
    [SerializeField] private Vector3 riseAxis = Vector3.up;
    [SerializeField] private bool followReceiver = true;

    [Space]
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    private int objectsOnPlate;
    private Vector3 receiverStartPosition;
    private Vector3 receiverRaisedPosition;
    private Vector3 plateWorldOffset;

    public bool isPressed => objectsOnPlate > 0;

    private void Awake()
    {
        Collider plateCollider = GetComponent<Collider>();
        plateCollider.isTrigger = true;

        if (receiver == null)
        {
            GameObject foundReceiver = GameObject.Find("receiver");
            if (foundReceiver != null)
            {
                receiver = foundReceiver.transform;
            }
        }

        CacheReceiverPositions();

        if (receiver != null)
        {
            plateWorldOffset = transform.position - receiver.position;
        }
    }

    private void OnValidate()
    {
        Collider plateCollider = GetComponent<Collider>();
        if (plateCollider != null)
        {
            plateCollider.isTrigger = true;
        }

        if (riseAxis.sqrMagnitude < 0.001f)
        {
            riseAxis = Vector3.up;
        }
    }

    private void Update()
    {
        if (receiver == null)
        {
            return;
        }

        Vector3 targetPosition = isPressed ? receiverRaisedPosition : receiverStartPosition;
        receiver.position = Vector3.MoveTowards(receiver.position, targetPosition, moveSpeed * Time.deltaTime);

        if (followReceiver)
        {
            transform.position = receiver.position + plateWorldOffset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!CanPress(other))
        {
            return;
        }

        objectsOnPlate++;
        if (objectsOnPlate == 1)
        {
            onPressed?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!CanPress(other))
        {
            return;
        }

        objectsOnPlate = Mathf.Max(0, objectsOnPlate - 1);
        if (objectsOnPlate == 0)
        {
            onReleased?.Invoke();
        }
    }

    private bool CanPress(Collider other)
    {
        if (!string.IsNullOrWhiteSpace(targetTag) && other.gameObject.tag == targetTag)
        {
            return true;
        }

        Transform current = other.transform;
        while (current != null)
        {
            if (current.name == targetObjectName)
            {
                return true;
            }

            current = current.parent;
        }

        return false;
    }

    private void CacheReceiverPositions()
    {
        if (receiver == null)
        {
            return;
        }

        receiverStartPosition = receiver.position;
        receiverRaisedPosition = receiverStartPosition + riseAxis.normalized * riseHeight;
    }
}
