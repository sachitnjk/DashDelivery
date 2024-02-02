using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveJobUI : MonoBehaviour
{
	private bool isTracked;

	[Header("Active Job UI References")]
	[SerializeField] private TextMeshProUGUI jType;
	[SerializeField] private TextMeshProUGUI jDestCount;
	[SerializeField] private TextMeshProUGUI jReward;

	private void Start()
	{
		isTracked = false;
	}

	public void InitJobUI(string type, string destCount, string reward)
	{
		jType.text = type;
		jDestCount.text = destCount;
		this.jReward.text = reward;
		this.gameObject.SetActive(true);
	}
	//Button OnClick function
	public void TrySetAsTracked()
	{
		isTracked = true;
	}
	public void SetTrackedJob(JobSO_Definer jobDefiner, TextMeshProUGUI tj_Type, TextMeshProUGUI tj_DestinationCount, TextMeshProUGUI tj_Reward)
	{
		if(isTracked) 
		{
			isTracked=false;

			tj_Type.text = jobDefiner.JobType.ToString();
			tj_Reward.text = jobDefiner.RewardExp.ToString();
			tj_DestinationCount.text = jobDefiner.JobDestinations.ToString();
		}
	}
}
