using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {

	// Use this for initialization
	void FixedUpdate () {
        Destroy(gameObject, 0.5f);
	}
}
