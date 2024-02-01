using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJobSelector : MonoBehaviour
{
	private PlayerInput playerInput;
	private InputAction tabAction;

	private int currentJobCount;
	[SerializeField] private int maxJobs;

	[SerializeField] private List<JobSO_Definer> activeJobSOList;

	public bool jobPanelActive{ get; private set; }
	private Dictionary<JobSO_Definer, List<Transform>> jobToDestinationLink;

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();
		tabAction = playerInput.actions["Tab"];

		jobPanelActive = false;
		currentJobCount = 0;

		jobToDestinationLink = new Dictionary<JobSO_Definer, List<Transform>>();
	}
	private void Update()
	{
		JobPanelInteractCheck();
	}

	private void JobPanelInteractCheck()
	{
		if(!jobPanelActive && tabAction.WasPerformedThisFrame())
		{
			jobPanelActive = true;
		}
		else if(jobPanelActive && tabAction.WasPerformedThisFrame()) 
		{
			jobPanelActive = false;
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
			Debug.Log("cannot pick more than " + currentJobCount + "jobs");
		}
	}
	private void AddToActive(JobSO_Definer jobDefiner, List<Transform> jobDestinations)
	{
		if(jobDefiner !=  null && jobDestinations != null) 
		{
			activeJobSOList.Add(jobDefiner);

			jobToDestinationLink[jobDefiner] = jobDestinations;
		}
		else
		{
			Debug.LogError("jobDefiner or jobDestination is invalid");
		}
	}

	public List<JobSO_Definer> GetActiveJobList()
	{
		if(activeJobSOList != null)
		{
			return activeJobSOList;
		}
		return null;
	}

	public List<Transform> GetActiveJobDestinations(JobSO_Definer jobDefiner)
	{
		if(jobToDestinationLink.TryGetValue(jobDefiner, out List<Transform> jobDestinations))
		{
			return jobDestinations;
		}
		return null;
	}


	public bool JobPanelStatusCheck()
	{
		if (jobPanelActive)
		{
			return true;
		}
		return false;
	}
}
