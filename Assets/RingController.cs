using UnityEngine;

public class RingController : Interactable
{
    private bool ringTrigger;
    private GameObject ring1, ring2, ring3;
    public float xAngle, yAngle, zAngle;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ringTrigger) return;
        if (ring1 != null)
        {
            ringTrigger = false;
            // else Rotate(xAngle 60.0f);
        }
    }
    public override void Interact(PlayerController caller)
    {
        ringTrigger = true;
    }
}
