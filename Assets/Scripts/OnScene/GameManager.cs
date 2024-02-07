using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public Action<JobSO_Definer> OnTracked;

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
	}

	public void OnTrackedInvoke(JobSO_Definer jobDefiner)
	{
		OnTracked?.Invoke(jobDefiner);
	}
}
