using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveJobUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI jType;
	[SerializeField] private TextMeshProUGUI jDestCount;
	[SerializeField] private TextMeshProUGUI jReward;

	public void InitJobUI(string type, string destCount, string reward)
	{
		jType.text = type;
		jDestCount.text = destCount;
		this.jReward.text = reward;
		this.gameObject.SetActive(true);
	}
}
