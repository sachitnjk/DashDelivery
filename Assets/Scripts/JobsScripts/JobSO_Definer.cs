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

	private bool jobPicked;
	private bool jobDropped;
	private bool jobComplete;

	private int randomJDIndex;

	private Transform jobDestination;

	public void AssignJob(GameObject jobStartObject)
	{
		//if(jobDestinationsList.Count == 0)
		//{
		//	Debug.Log("No Jobs available");
		//	return;
		//}

		//randomJDIndex = Random.Range(0, jobDestinationsList.Count);
		//jobDestination = jobDestinationsList[randomJDIndex];

		//CalculateMinimumTimeRequired(jobDestination, jobStartObject.transform);

		Debug.Log(this.name + "job called");
	}

	private void CalculateMinimumTimeRequired(Transform destination, Transform jobStartTransform)
	{
		distanceToJob = Vector3.Distance(destination.position, jobStartTransform.position);

		minTimeRequired = distanceToJob / playerSpeed;
		timeLimit = minTimeRequired + 20f;

		Debug.Log("Min time req" + minTimeRequired);
		Debug.Log("Total time limit" + timeLimit);
	}
}
