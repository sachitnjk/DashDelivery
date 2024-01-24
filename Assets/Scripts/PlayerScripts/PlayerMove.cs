using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
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
	private Vector3 moveDirection;
	private bool isGrounded;

	[Header("Serializable Movement Attributes")]
	[SerializeField] private float moveSpeed;
	[SerializeField] private float gravity = 10f;
	[SerializeField] private LayerMask groundLayer;
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
		ApplyGravity();
	}

	private void Move()
	{
		moveInput = moveAction.ReadValue<Vector2>();

		if(moveInput != Vector2.zero) 
		{
			moveInput = moveAction.ReadValue<Vector2>();

			moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
			moveDirection = playerCam.transform.TransformDirection(moveDirection);
			moveDirection.y = 0;

			playerCharController.Move(moveDirection * moveSpeed * Time.deltaTime);
		}
	}

	private void ApplyGravity()
	{
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, .01f, groundLayer);
		Debug.Log(isGrounded);
		if (!isGrounded) 
		{
			playerCharController.Move(Vector3.down * gravity * Time.deltaTime);
		}
	}
}
