using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeliveryHandler : MonoBehaviour
{
	private Action e_JobPickup;
	private Action e_JobDrop;

	private int maxAttempts;
	private int randomJobDisplayCount;
	private bool playerAtStation;

	private PlayerInput playerInput;
	private InputAction interactAction;
	private JobSO_Definer jobDefiner;
	private Transform randomDestination;
	private PlayerJobSelector playerJobSelector;
	private List<Transform> randomizedDestinations;

	[SerializeField] private List<JobSO_Definer> jobList;
	[SerializeField] private List<Transform> possibleDestinations;

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();
		interactAction = playerInput.actions["Interact"];

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
			playerJobSelector = other.gameObject.GetComponent<PlayerJobSelector>();
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playerAtStation = false;
			playerJobSelector = null;
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

	private List<Transform> RandomizeJobDestinations(List<Transform> destinations, JobSO_Definer selectedJob)
	{
		if (destinations != null && selectedJob != null)
		{
			randomizedDestinations = new List<Transform>();

			for (int i = 0; i < selectedJob.JobDestinations; i++)
			{
				maxAttempts = 4;

				while(maxAttempts > 0)
				{
					randomDestination = destinations[UnityEngine.Random.Range(0, destinations.Count)];
					if(!randomizedDestinations.Contains(randomDestination))
					{
						randomizedDestinations.Add(randomDestination);
						break;
					}
					maxAttempts--;
				}
			}
		}
		return randomizedDestinations;
	}

	//Public Job Handlers
	private void HandleJobPicked()
	{
		randomJobDisplayCount = UnityEngine.Random.Range(0, jobList.Count);
		jobDefiner = jobList[randomJobDisplayCount];

		RandomizeJobDestinations(possibleDestinations, jobDefiner);
		if(playerJobSelector != null) 
		{
			playerJobSelector.TryAddJob(jobDefiner, randomizedDestinations);
		}
	}
	private void HandleJobDropped()
	{

	}
}
