﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    new public Rigidbody rigidbody;
    private bool useGravity;

    void Start()
	{
		cameraT = Camera.main.transform; // Camera initial transform cache
		controller = GetComponent<CharacterController>(); // Fetching the component at Start() to keep the variables private, less room for error.
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // input detection
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

	void Move(Vector2 inputDir, bool running)
	{
		if (inputDir != Vector2.zero && !bUseCameraControlRotation)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		}

		if(bUseCameraControlRotation)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		}
		
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		if (velocityY > -5) { velocityY += Time.deltaTime * gravity; }
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

		switch (currentSpeed != 0)
		{
			case true:

			isMoving = true;

			break;

			case false:

			isMoving = false;

			break;
		}

	}

	public void Jump()
	{
		if (controller.isGrounded)
		{
			float jumpVelocity = Mathf.Sqrt(-3 * gravity * jumpHeight);
			velocityY = jumpVelocity;
			
			rigidbody.useGravity = false;
        if (useGravity) rigidbody.AddForce(Physics.gravity * (rigidbody.mass * rigidbody.mass));

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
	[Range(0,10f)] public float drawerinteractdistance = 0.5f;
	private void DoRay()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit, 1000)) return;
        var hitPoint = hit.point;
        var objectHit = hit.transform;
		var _distance = Vector3.Distance(hitPoint, transform.position);
		if  ( _distance > drawerinteractdistance)
			return;

        
        var isDrawerController = objectHit.gameObject.TryGetComponent(out Drawer dc);
		if (!isDrawerController)
			return;
         var drawer = dc.GetController();

        if (Input.GetMouseButtonDown(0))
		{
			drawer.Interact();
			Debug.Log("Click");
		}
           
    }

}