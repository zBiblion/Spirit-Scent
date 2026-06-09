using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PressureButton : MonoBehaviour
{
    [Tooltip("The tag of objects that can press the button (e.g. 'Player' or 'Cube')")]
    [SerializeField] private string targetTag = "Player";
    
    [Space]
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    private int _objectsOnPlate = 0;
    
    public bool isPressed => _objectsOnPlate > 0;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object stepping on the plate has the right tag
        if (other.CompareTag(targetTag))
        {
            _objectsOnPlate++;
            
            // Only trigger if this is the first object on the plate
            if (_objectsOnPlate == 1)
            {
                onPressed?.Invoke();
                Debug.Log("Button Pressed!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            _objectsOnPlate--;
            
            // Only release if there are no more objects on the plate
            if (_objectsOnPlate <= 0)
            {
                _objectsOnPlate = 0;
                onReleased?.Invoke();
                Debug.Log("Button Released!");
            }
        }
    }
}
