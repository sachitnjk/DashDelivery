using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DeliveryJob")]
public class JobSO_Definer : ScriptableObject
{
	[field: SerializeField] public float rewardExp{ get; private set; }
	[field: SerializeField] private List<GameObject> rewardItems;
	[field: SerializeField] public int jobDestinations { get; private set; }
}
