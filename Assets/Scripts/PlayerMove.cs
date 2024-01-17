using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
	private PlayerInput playerInput;
	private InputAction moveAction;

	private CharacterController playerCharController;

	private Vector2 moveInput;
	private Vector3 targetVector;

	[Header("Serializable Movement Attributes")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private Camera playerCam;

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();

		if (playerInput != null)
		{
			moveAction = playerInput.actions["Move"];
		}

		playerCharController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		moveInput = moveAction.ReadValue<Vector2>();


		targetVector = new Vector3(moveInput.x, 0, moveInput.y);
		MoveTowardTarget(targetVector);
	}

	private Vector3 MoveTowardTarget(Vector3 targetVector)
	{
		float speed = moveSpeed * Time.deltaTime;

		//camera Y offset
		targetVector = Quaternion.Euler(0, playerCam.transform.eulerAngles.y, 0) * targetVector;

		Vector3 targetPosition = transform.position + targetVector * speed;
		transform.position = targetPosition;
		return targetVector;
	}
}
