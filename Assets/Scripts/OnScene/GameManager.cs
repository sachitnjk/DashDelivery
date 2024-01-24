using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private void Awake()
	{
		if (instance == null)
		{
			instance = new GameManager();
		}
		else
			Destroy(this.gameObject);
	}

	public Vector3 jobStartPos{ get; private set; }

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
}
