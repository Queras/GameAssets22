using UnityEngine;

public class openLid : Interactable
{
    public GameObject lid;
    public bool doLerp;
    private float rotationAlpha;
    public float maxOpenAngle = 90;
    public float rotationSpeed = 1;
    public BoxCollider boxCollider;
    public Vector3 startAngle;
    public bool isOneShoot, hasShoot;
    public bool isLidOpen = false;
    public CapsuleCollider blueLense;
    public override void Interact(PlayerController caller)
    {
        if (isOneShoot && hasShoot) return;
        doLerp = true;




    }







    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        rotationAlpha = startAngle.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!doLerp) return; // if we havent interacted with object, do nothing
        lid.transform.localRotation = Quaternion.Euler(startAngle.x, startAngle.y, rotationAlpha); // setting rotation
        if (!isLidOpen) // if the door has not been opened yet
        {
            if (rotationAlpha <= maxOpenAngle) // if rotationAlpha has not reached maxOpenAngle
            {
                rotationAlpha += rotationSpeed; // Increase rotationAlpha by speed
                return;
            }
            isLidOpen = true; // If we have reached desired rotationAlpha set door as open
            blueLense.enabled = true;
        }
    }
}
