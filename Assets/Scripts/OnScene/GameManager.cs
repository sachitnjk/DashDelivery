using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public Action<JobSO_Definer> OnTracked;
	public Action OnNewDay;

	//------TO BE REMOVED, TESTING ONLY---------
	private PlayerInput playerInput;
	private InputAction debugActionX;
	//------------------------------------------

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	public Vector3 jobStartPos{ get; private set; }

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;

		//------TO BE REMOVED, TESTING ONLY---------
		playerInput = InputProvider.GetPlayerInput();
		debugActionX = playerInput.actions["DebugX"];
		//------------------------------------------
	}

	//------TO BE REMOVED, TESTING ONLY---------
	private void Update()
	{
		if(debugActionX != null && debugActionX.WasPerformedThisFrame()) 
		{
			OnNewDayInvoke();
		}
	}

	//------------------------------------------

	public void OnTrackedInvoke(JobSO_Definer jobDefiner)
	{
		OnTracked?.Invoke(jobDefiner);
	}
	public void OnNewDayInvoke()
	{
		OnNewDay?.Invoke();
	}
}
