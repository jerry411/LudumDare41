using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSelection : MonoBehaviour {

    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
	
    // Use this for initialization
	void Awake ()
    {
		switch(PlayerPrefs.GetInt("carNumberSelected", 1))
        {
            case 1:
                car1.SetActive(true);
                GameObject.Destroy(car2);
                GameObject.Destroy(car3);
                break;
            case 2:
                GameObject.Destroy(car1);
                car2.SetActive(true);
                GameObject.Destroy(car3);
                break;
            case 3:
                GameObject.Destroy(car1);
                GameObject.Destroy(car2);
                car3.SetActive(true);
                break;
        }
	}
	
}
