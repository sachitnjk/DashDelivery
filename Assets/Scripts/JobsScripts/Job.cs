using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour
{
	private List<Transform> randomizedDestinations;
	private Transform randomDestination;

	public int RandomizeJobDestinations(List<Transform> destinations, JobSO_Definer selectedJob)
	{
		if(destinations != null && selectedJob != null)
		{
			randomizedDestinations = new List<Transform>();
			
			for(int i = 0; i < selectedJob.jobDestinations;  i++) 
			{
				randomDestination = destinations[Random.Range(0, selectedJob.jobDestinations)];
				randomizedDestinations.Add(randomDestination);
			}
		}
		return randomizedDestinations.Count;
	}
}
