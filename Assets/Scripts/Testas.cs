using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testas : MonoBehaviour {

    private GameObject player;
    public int pakelimuSk;
    // Use this for initialization
    void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            player = GameObject.Find("Bullet(Clone)");
        }
        if (Input.GetKeyDown("space") && pakelimuSk>0)
        {
            print("space key was pressed");
            GetComponent<Rigidbody2D>().AddForce(transform.up * 500 + transform.right*500);
            pakelimuSk = pakelimuSk - 1;
        }
            
    }
}
