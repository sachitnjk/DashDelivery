using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeliveryHandler : MonoBehaviour
{
	private Action e_JobPickup;
	private Action e_JobDrop;

	private int randomJobDisplayCount;

	private bool playerAtStation;

	private PlayerInput playerInput;
	private InputAction interactAction;
	private JobSO_Definer jobDefiner;

	public List<JobSO_Definer> jobList;

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();
		interactAction = playerInput.actions["Interact"];

		randomJobDisplayCount = UnityEngine.Random.Range(0, jobList.Count);

		jobDefiner = jobList[randomJobDisplayCount];

		playerAtStation = false;

		e_JobPickup += HandleJobPicked;
	}
	private void OnDestroy()
	{
		e_JobPickup -= HandleJobPicked;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			playerAtStation = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerAtStation = false;
		}
	}

	private void Update()
	{
		if(playerAtStation)
		{
			if(playerInput != null)
			{
				if (interactAction.WasPressedThisFrame())
				{
					e_JobPickup?.Invoke();
				}
			}
		}
	}

	//Public Job Handlers
	public void HandleJobPicked()
	{
		jobDefiner.AssignJob(this.gameObject);
	}
	public void HandleJobDropped()
	{

	}
}
