using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateJob")]
public class JobSO_Definer : ScriptableObject
{
	public enum jobTypes
	{
		Delivery,
		Collection,
		Escort,
		Surveilence,
		Investigation,
		Defend,
		Build
	}

	[field: SerializeField] private List<GameObject> rewardItems;
	[field: SerializeField] public jobTypes JobType{ get; private set;}
	[field: SerializeField] public float RewardExp{ get; private set; }
	[field: SerializeField] public int JobDestinations { get; private set; }
}
