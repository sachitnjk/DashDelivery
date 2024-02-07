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
	private List<Transform> trackedJobDestinations;

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();
		tabAction = playerInput.actions["Tab"];

		jobPanelActive = false;
		currentJobCount = 0;

		jobToDestinationLink = new Dictionary<JobSO_Definer, List<Transform>>();
		trackedJobDestinations = new List<Transform>();
	}
	private void OnEnable()
	{
		GameManager.instance.OnTracked += HandleOnTracked;
	}
	private void OnDestroy()
	{
		GameManager.instance.OnTracked -= HandleOnTracked;
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
	private void HandleOnTracked(JobSO_Definer jobDefiner)
	{
		foreach(Transform previousDest in trackedJobDestinations) 
		{
			previousDest.gameObject.SetActive(false);
		}

		//if (jobToDestinationLink.TryGetValue(jobDefiner, out List<Transform> jobDestinations))
		//{
		//	trackedJobDestinations = jobDestinations;
		//	foreach (Transform destination in trackedJobDestinations)
		//	{
		//		destination.gameObject.SetActive(true);
		//	}
		//}
		trackedJobDestinations = GetActiveJobDestinations(jobDefiner);

		foreach (Transform destination in trackedJobDestinations)
		{
			if (destination.gameObject != null)
			{
				destination.gameObject.SetActive(true);
			}
		}
	}

	public string GetJobType(JobSO_Definer jobDefiner)
	{
		return jobDefiner.JobType.ToString();
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
