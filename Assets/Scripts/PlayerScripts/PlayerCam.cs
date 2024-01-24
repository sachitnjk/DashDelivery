using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{
	[Header("Camera Position and sensitivity")]
	[SerializeField][Range(0.1f, 1f)] private float sensitivity;
	[SerializeField] private GameObject playerObject;

	private PlayerInput playerInput;
	private InputAction lookAction;

	private Vector3 playerForward;
	private Vector2 lookDelta;

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();
		lookAction = playerInput.actions["Look"];
	}

	private void Update()
	{
		lookDelta = lookAction.ReadValue<Vector2>();

		// Rotate the camera based on the look action
		RotateCamera(lookDelta.x);
	}

	private void RotateCamera(float lookInputX)
	{
		// Adjust the rotation based on sensitivity
		float rotationAmount = lookInputX * sensitivity;

		// Rotate the camera around its Y-axis
		transform.RotateAround(playerObject.transform.position, Vector3.up, rotationAmount);

		Vector3 playerForward = transform.forward;
		playerForward.y = 0; // Ensure no rotation in the y-axis
		playerObject.transform.forward = playerForward.normalized;
	}
}