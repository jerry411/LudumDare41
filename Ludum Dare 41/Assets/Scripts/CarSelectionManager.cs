using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectionManager : MonoBehaviour 
{
	[SerializeField] private List <GameObject> StatDropdowns = new List <GameObject>();

	public void DisplayCarStats(int StatDropdownIndex)
	{
		StatDropdowns[StatDropdownIndex].SetActive(true);
	}
	public void HideCarStats(int StatDropdownIndex)
	{
		StatDropdowns[StatDropdownIndex].SetActive(false);
	}
}
