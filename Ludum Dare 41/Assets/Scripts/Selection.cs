using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public void SelectCar(int carNumber)
    {
        PlayerPrefs.SetInt("carNumberSelected", carNumber);
    }
}
