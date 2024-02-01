using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveJobUI : MonoBehaviour
{
	public TextMeshProUGUI destinationCount;
	public TextMeshProUGUI reward;

	public void InitJobUI(string destCount, string jReward)
	{
		destinationCount.text = destCount;
		reward.text = jReward;
		this.gameObject.SetActive(true);
	}
}
