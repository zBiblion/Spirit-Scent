using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpiritScent_GodViewController : MonoBehaviour
{
    public Interactable[] interactableObjects;
    public InteractableEvent interactedObject; // was plain UnityEvent — can't Invoke with an argument

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Interactable interactableObject = hit.transform.GetComponent<Interactable>();

                if (interactableObject != null)
                {
                    interactedObject.Invoke(interactableObject);
                }
            }
        }
    }

    // was: interactableObjects = obj (can't assign Interactable to Interactable[])
    public void AddInteractable(Interactable obj)
    {
        var list = new List<Interactable>(interactableObjects) { obj };
        interactableObjects = list.ToArray();
    }
}