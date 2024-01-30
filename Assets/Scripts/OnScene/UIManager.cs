using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager uiManagerInstance;

	private bool basePanelActive;

	[SerializeField] private PlayerJobSelector playerJobSelector;

	[Header("UI Elements References")]
	[SerializeField] private GameObject baseUIPanel;
	[SerializeField] private GameObject jobsPanel;
	[SerializeField] private GameObject settingsPanel;
	[SerializeField] private GameObject controlsPanel;

	private void Awake()
	{
		if (uiManagerInstance == null)
		{
			uiManagerInstance = new UIManager();
		}
		else
			Destroy(this.gameObject);
	}

	private void Start()
	{
		basePanelActive = false;
		if(baseUIPanel != null)
		{
			baseUIPanel.SetActive(false);
		}
	}

	private void Update()
	{
		BasePanelToggleCheck();
	}

	private void BasePanelToggleCheck()
	{
		if (!basePanelActive && playerJobSelector.JobPanelStatusCheck())
		{
			Cursor.lockState = CursorLockMode.Confined;
			basePanelActive = true;
			baseUIPanel.SetActive(true);
		}
		else if (basePanelActive && !playerJobSelector.JobPanelStatusCheck())
		{
			Cursor.lockState = CursorLockMode.Locked;
			basePanelActive = false;
			baseUIPanel.SetActive(false);
		}
	}

	//Button Click Functions
	public void EnablePanel(string panelToActivate)
	{
		if(basePanelActive)
		{
			jobsPanel.SetActive(false);
			settingsPanel.SetActive(false);
			controlsPanel.SetActive(false);

			switch(panelToActivate) 
			{
				case "Jobs":
					jobsPanel.SetActive(true);
					break;
				case "Settings":
					settingsPanel.SetActive(true); 
					break;
				case "Controls":
					controlsPanel.SetActive(true);
					break;
				default:
					Debug.LogError("Enter a valid panel name");
					break;
			}
		}
	}
}
