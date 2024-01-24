using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryHandler : MonoBehaviour
{
	private Action e_JobPickup;
	private Action e_JobDrop;

	//Job Event Invokers
	private void OnJobPicked()
	{
		e_JobPickup?.Invoke();
	}
	private void OnJobDropped()
	{
		e_JobDrop?.Invoke();
	}

	//Public Job Handlers
	public void HandleJobPicked()
	{

	}
	public void HandleJobDropped()
	{

	}
}
