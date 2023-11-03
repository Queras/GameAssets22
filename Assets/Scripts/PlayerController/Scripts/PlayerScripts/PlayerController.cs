using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Character Attributes")]
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float gravity = -12;
    public float jumpHeight = 1;
    [Range(0, 1)]
    public float airControlPercent = 1;

    [Header("Smoothen's The Turn Rotation")]
    [Range(0, 0.2f)]
    public float turnSmoothTime = 0.01f;
    float turnSmoothVelocity;

    [Header("Extra Control (Usually Fine at 0 Though)")]
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    Transform cameraT;
    CharacterController controller;

    [Header("Character Movement Check")]
    public bool isMoving;

    [Header("Camera Setting")]
    public bool bUseCameraControlRotation; // makes it so the rotation of the capsule follows the camera, Turning it off will make it so you can rotate with your camera without your character turning too.

    public Rigidbody m_rigidbody;
    private bool useGravity;

    [HideInInspector] public bool viewMaster = false;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        cameraT = mainCamera.transform;
        controller = GetComponent<CharacterController>(); // Fetching the component at Start() to keep the variables private, less room for error.
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HasVM();

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey(KeyCode.LeftShift);

        // Movement function using the input detection above.
        Move(inputDir, running);

        // Jump handling, got its own funciton as its easier to transition to an animation character this way.
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        DoRay();

    }
    void CameraMovement(Vector2 inputDir)
    {
        if (inputDir != Vector2.zero && !bUseCameraControlRotation)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }

        if (bUseCameraControlRotation)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));

        }

    }
    void Move(Vector2 inputDir, bool running)
    {
        CameraMovement(inputDir);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        if (velocityY > -5) { velocityY += Time.deltaTime * gravity; }
        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        if (isUsingVm)
        {
            velocity = Vector3.up * velocityY;

        }
        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
        isMoving = currentSpeed != 0 ? true : false;
        /*
        switch (currentSpeed != 0)
        {
            case true:

                isMoving = true;

                break;

            case false:

                isMoving = false;

                break;
        }
        */ //John legacy
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-3 * gravity * jumpHeight);
            velocityY = jumpVelocity;

            m_rigidbody.useGravity = false;
            if (useGravity) m_rigidbody.AddForce(Physics.gravity * (m_rigidbody.mass * m_rigidbody.mass));

        }


    }

    float GetModifiedSmoothTime(float smoothTime)
    {
        if (controller.isGrounded)
        {
            return smoothTime;
        }

        if (airControlPercent == 0)
        {
            return float.MaxValue;
        }
        return smoothTime / airControlPercent;
    }
    [Range(0, 10f)] public float interactDistance = 0.5f; //Edit Change to defaultinteractdistance if global.
    public LayerMask interactableLayerMask;
    private void DoRay()
    {
        if (!Input.GetMouseButtonDown(1)) return;  //is playerHasControl a new bool, floot or what? (edit;same as controller?)
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit)) return; //does this refer to layer in inspector? and in what context does it ned to be in?
        if (Vector3.Distance(hit.point, transform.position) > interactDistance) return;
        var interactable = hit.transform.gameObject.GetComponent<IInteractable>();
        if (interactable != null) { interactable.Interact(this); }

    }
    public Image vignet;
    private bool isUsingVm;
    [SerializeField] private List<LensColor> lenseInvetory;
    public void AddToLenseInventory(LensColor color)
    {
        lenseInvetory.Add(color);

    }
    private LensColor lastUsedLense;
    private int lastUsedIndex;
    public GameObject redLense, greenLense, blueLense;
    public void HasVM()
    {
        if (!viewMaster || vignet == null) return;
        if (Input.GetKey(KeyCode.E))

        {
            vignet.enabled = true;
            isUsingVm = true;
            if (lenseInvetory.Count > 0)
            {
                if (Input.mouseScrollDelta.y > 0)
                {
                    lastUsedIndex++; //is scrolling up
                }
                else
                    if (Input.mouseScrollDelta.y < 0 && lastUsedIndex > 0)
                {
                    lastUsedIndex--;
                }
                if (lastUsedIndex == lenseInvetory.Count) lastUsedIndex = 0;
                abc();
                switch (lenseInvetory[lastUsedIndex])
                {
                    case LensColor.Red:
                        redLense.SetActive(true);
                        break;
                    case LensColor.Green:
                        greenLense.SetActive(true);
                        break;
                    case LensColor.Blue:
                        blueLense.SetActive(true);
                        break;
                    default: break;
                }
            }

        }
        else
        {
            abc();
            vignet.enabled = false;
            isUsingVm = false;
        }
        if (vignet.enabled != true) return;


        // when using VM with no lense BW is default,
        // when first lense is in inventory is new default.
        // when two or more lenses is in inventory remember last lense used as default.

    }
    private void abc()
    {
        blueLense.SetActive(false);
        greenLense.SetActive(false);
        redLense.SetActive(false);
    }
}




