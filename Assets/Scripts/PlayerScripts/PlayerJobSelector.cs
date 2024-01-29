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

	public bool tabActive{ get; private set; }
	private Dictionary<JobSO_Definer, List<Transform>> jobDestinationDict;

	private void Start()
	{
		playerInput = InputProvider.GetPlayerInput();
		tabAction = playerInput.actions["Tab"];

		tabActive = false;
		currentJobCount = 0;

		jobDestinationDict = new Dictionary<JobSO_Definer, List<Transform>>();
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
		if(jobDefiner !=  null && jobDestinations != null) 
		{
			activeJobSOList.Add(jobDefiner);

			jobDestinationDict[jobDefiner] = jobDestinations;

			Debug.Log(jobDefiner);
			foreach(Transform dest in GetJobDestinations(jobDefiner))
			{
				Debug.Log(dest.gameObject.name);
			}
		}
		else
		{
			Debug.LogError("jobDefiner or jobDestination is invalid");
		}
	}

	public List<Transform> GetJobDestinations(JobSO_Definer jobDefiner)
	{
		if(jobDestinationDict.TryGetValue(jobDefiner, out List<Transform> jobDestinations))
		{
			return jobDestinations;
		}
		return null;
	}
}
