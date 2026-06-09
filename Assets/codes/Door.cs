using UnityEngine;

public class Door : Interactable
{
    public override void Interact()
    {
        Debug.Log("Door is now open!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PressureButton>() != null &&
            other.gameObject.GetComponent<PressureButton>().isPressed)
            OnInteracted(); // now accessible since base method is protected
    }
}