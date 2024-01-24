using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DeliveryJob")]
public class JobSO_Definer : ScriptableObject
{
	[SerializeField] private List<Transform> jobDestinationsList;
	[SerializeField] private List<GameObject> rewardItems;

	[SerializeField] private float rewardExp;
	[SerializeField] private float playerSpeed;

	private float timeLimit;
	private float minTimeRequired;
	private float distanceToJob;

	private int randomJDIndex;

	private Transform jobDestination;
	private Vector3 jobStartPoint;

	public void AssignJob()
	{
		if(jobDestinationsList.Count == 0)
		{
			Debug.Log("No Jobs available");
			return;
		}

		randomJDIndex = Random.Range(0, jobDestinationsList.Count);
		jobDestination = jobDestinationsList[randomJDIndex];

		CalculateMinimumTimeRequired(jobDestination);
	}

	private void CalculateMinimumTimeRequired(Transform destination)
	{
		distanceToJob = Vector3.Distance(destination.position, jobStartPoint);

		minTimeRequired = distanceToJob / playerSpeed;
		timeLimit = minTimeRequired + 20f;

		Debug.Log("Min time req" + minTimeRequired);
		Debug.Log("Total time limit" + timeLimit);
	}
}
