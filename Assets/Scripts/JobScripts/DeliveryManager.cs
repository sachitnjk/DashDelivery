using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
	private Action OnJobPickup;
	private Action OnJobDrop;

	private void Start()
	{
		OnJobPickup += HandlePickUp;
		OnJobDrop += HandleDrop;
	}
	private void OnDestroy()
	{
		OnJobPickup -= HandlePickUp;
		OnJobDrop -= HandleDrop;
	}

	//Event Invokes
	private void JobPickup()
	{
		OnJobPickup?.Invoke();
	}
	private void JobDrop()
	{
		OnJobDrop?.Invoke();
	}

	//Event Handlers
	public void HandlePickUp()
	{
		//Randomize Jobs Picked
		Debug.Log("Job Picked");
	}
	public void HandleDrop()
	{
		//Job Drop Rewarding
		Debug.Log("Job Dropped");
	}
}
