using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {


    // Use this for initialization
    public float speed = 0.5f;
    public Vector3 from = new Vector3(0f, 0f, 0f);
    public Vector3 to = new Vector3(0f, 0f, 70f);
    public bool pradzia = true;
    private Bullet_Fire bulletFireScript;


    // Update is called once per frame
  
    void FixedUpdate()
    {
        bool shoot = Input.GetButtonDown("Fire1");
        if (shoot == true)
        {
            pradzia = false;
            GameObject.Find("Bullet").transform.parent = null;
        }
            
    }
        void Update()
    {
        if (pradzia)
        {
            float t = (Mathf.Sin(Time.time * speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
            transform.eulerAngles = Vector3.Lerp(from, to, t);
            
          //  if (bulletFireScript.shoot == true)
           //     pradzia = false;
        }
        // Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // float angle = Mathf.Atan2(transform.eulerAngles.y, transform.eulerAngles.x) * Mathf.Rad2Deg;
        // Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime);
    }


}
