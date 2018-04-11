using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Fire : MonoBehaviour
{

    public float bulletForce = 50000.0f;
    public RigidbodyType2D bodyType;
    public bool shoot;
    bool once = false;
    public static bool bulletInAir;
    void Start()
    {
        bulletInAir = false;
    }
    void FixedUpdate()
    {   
        shoot = Input.GetButtonDown("Fire1"); 
        if(shoot&&!once)
        {
            if (gameObject.name == "Bullet")
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
                once = true;
                bulletInAir = true;
            }
            
           // gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
           
        }
    }
}
