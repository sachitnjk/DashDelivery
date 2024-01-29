using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJobSelector : MonoBehaviour
{
	private PlayerInput playerInput;
	private InputAction tabAction;

	[SerializeField] private int maxJobs;
	private int currentJobCount;

	[SerializeField] private List<JobSO_Definer> activeJobSOList;

	public bool tabActive{ get; private set; }

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();
		tabAction = playerInput.actions["Tab"];

		tabActive = false;
		currentJobCount = 0;
	}
	private void Update()
	{
		JobTabCheck();
	}

	private void JobTabCheck()
	{
		if(!tabActive && tabAction.WasPerformedThisFrame())
		{
			tabActive = true;
		}
		else if(tabActive && tabAction.WasPerformedThisFrame()) 
		{
			tabActive = false;
		}
	}
	public void TryAddJob(JobSO_Definer jobSO, List<Transform> jobDestList)
	{
		if(currentJobCount < maxJobs)
		{
			currentJobCount++;
			AddToActive(jobSO, jobDestList);
		}
		else
		{
			Debug.Log(currentJobCount);
			Debug.Log("cannot pick more than max Jobs");
		}
	}
	private void AddToActive(JobSO_Definer jobDefiner, List<Transform> jobDestinations)
	{
		activeJobSOList.Add(jobDefiner);
	}
}
