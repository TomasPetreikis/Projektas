using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBar : MonoBehaviour {

    // Use this for initialization
    public float totalBoost;
    public float currentBoost;
	void Start () {
        currentBoost = totalBoost;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")&&currentBoost!=0)
        {
            LoseBoost();
        }
	}
    void LoseBoost()
    {
        currentBoost -= 1;
        transform.localScale = new Vector3((currentBoost / totalBoost), 1, 1);
    }
}
