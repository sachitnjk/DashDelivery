using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DeliveryJob")]
public class JobSO_Definer : ScriptableObject
{
	[SerializeField] private float rewardExp;
	[SerializeField] private List<GameObject> rewardItems;
	[field: SerializeField] public int jobDestinations { get; private set; }
}
