using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {

    public bool firstTime = true;
    public Rigidbody2D bullet;
    // Use this for initialization
    void Start()
    {
    }
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R))
        {
            Reset();

        }
	}

    void Reset()
    {
        Debug.Log("restart function called");
        //        Application.LoadLevel(Application.loadedLevel);            //old function
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
