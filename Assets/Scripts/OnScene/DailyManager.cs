using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyManager : MonoBehaviour
{
	private enum Days
	{
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday,
		Sunday
	}

	private Days currentDay;
	private int daysEnumLength;

	private void Start()
	{
		daysEnumLength = Enum.GetValues(typeof(Days)).Length;

		currentDay = Days.Monday;
		Debug.Log(currentDay.ToString());
		GameManager.instance.OnNewDay += CycleToNextDay;
	}
	private void OnDestroy()
	{
		GameManager.instance.OnNewDay -= CycleToNextDay;
	}

	private void CycleToNextDay()
	{
		currentDay = (Days)(((int)currentDay + 1) % 7);
		Debug.Log(currentDay.ToString());
	}
}
