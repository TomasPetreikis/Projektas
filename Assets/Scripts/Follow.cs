using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    private GameObject player;
    public Transform leftBorder;
    public Transform rightBorder;

    void Start() {
    
    }

    void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        if (player == null)
        {
            player = GameObject.Find("Bullet(Clone)");
        }
        else
        {
            newPosition.x = player.transform.position.x;
            newPosition.x = Mathf.Clamp(newPosition.x, leftBorder.position.x, rightBorder.position.x);
            transform.position = newPosition;
        }
    }
}
