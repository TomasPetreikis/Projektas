using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follownr2 : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset1 = new Vector3(0f, 0f, 0f), offset, newPosition;
    private float i;
    private int max = 15, min = 1;
    public float speed = 0.4f;
    public Transform ceilingborder, groundborder;
    bool shoot = false;

    void Start()
    {
        offset = transform.position;
        player = GameObject.Find("Bullet");
        bool shoot = Input.GetButtonDown("Fire1");
    }

    void LateUpdate()
    {

        //if (player.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
        if (Bullet_Fire.bulletInAir)
        {
            newPosition = player.transform.position;
            newPosition.y = Mathf.Clamp(newPosition.y, groundborder.position.y, ceilingborder.position.y); // nuo left border iki max1
            newPosition.x = Mathf.Clamp(newPosition.x, -15, 100000);
            transform.position = newPosition + offset + offset1;

            i=Mathf.Lerp(min, max, Time.time * speed);
            offset1[0] = i;
        }
        
   }
}

