using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private Animator _anim;
    private bool _isUp = false;
    public Animator doorAnimator; // drag door here in Inspector

    void Start()
    {
        _anim = GetComponent<Animator>();
        Debug.Log($"LeverScript initialized on {gameObject.name}. IMPORTANT: This object MUST have a Collider to be clickable!");
    }

    void Update()
    {
        // Test key (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithLever();
        }

        // Point-and-Click Raycast logic
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit is the one this script is attached to
                if (hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log($"RAYCAST HIT: {gameObject.name} clicked!");
                    InteractWithLever();
                }
            }
        }
    }

    public void InteractWithLever()
    {
        if (_anim != null)
        {
            _isUp = !_isUp;
            _anim.SetBool("LeverUp", _isUp);
            
            if (_isUp && doorAnimator != null)
                doorAnimator.SetTrigger("OpenDoor");
        }
    }
}