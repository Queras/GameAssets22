using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class DoorControl : Interactable
{

    public Animator door = null;
    public bool haskey = false;
    public bool isDoorOpen = false;
    public bool useCodeAnimation;
    public bool doLerp;
    private float rotationAlpha;
    public float maxOpenAngle = 90;
    public float rotationSpeed = 1;
    public BoxCollider boxCollider;
    public Vector3 startAngle;
    public bool isOneShoot, hasShoot;
    public override void Interact(PlayerController caller)
    {
        if (doLerp) return; //If we are animating ignore input
        Debug.Log("Clicked on door");
        if (isOneShoot && hasShoot) return;
        if (haskey)
        {

            Debug.Log("Door Open");
            if (door)
            {
                door.SetTrigger("openDoor");
                if (isOneShoot is true) hasShoot = true;
            }
            if (useCodeAnimation) doLerp = true;


        }
        else if (door == null)
        {
            Debug.Log("No door");
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<Animator>();
        if (door == null) { useCodeAnimation = true; }
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        rotationAlpha = startAngle.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!useCodeAnimation) return; // do nothing if we have animator
        if (!doLerp) return; // if we havent interacted with object, do nothing
        transform.localRotation = Quaternion.Euler(startAngle.x, rotationAlpha, startAngle.z); // setting rotation
        if (!isDoorOpen) // if the door has not been opened yet
        {
            if (rotationAlpha <= maxOpenAngle) // if rotationAlpha has not reached maxOpenAngle
            {
                rotationAlpha += rotationSpeed; // Increase rotationAlpha by speed
                return;
            }
            isDoorOpen = true; // If we have reached desired rotationAlpha set door as open
        }
        else // if the door is open
        {
            if (rotationAlpha >= startAngle.y) // if rotationAlpha is greater than startAngle
            {
                rotationAlpha -= rotationSpeed; // Reduce rotationAlpha by speed
                return;
            }
            isDoorOpen = false; // Door is closed
        }

        doLerp = false; // we are done animating
        if (isOneShoot is true) hasShoot = true;
    }
}
