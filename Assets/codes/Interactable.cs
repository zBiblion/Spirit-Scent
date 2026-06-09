using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractableEvent : UnityEvent<Interactable> { }

public abstract class Interactable : MonoBehaviour
{
    public InteractableEvent onInteracted;

    public virtual void Interact() { }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Interactable>() != null &&
            collision.gameObject.GetComponent<Door>() == null)
            OnInteracted();
    }

    protected void OnInteracted()  // was private — Door.cs needs to call this
    {
        onInteracted?.Invoke(this);
        Interact();
    }
}