using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovements : MonoBehaviour {

    public float speed;
    public float distance;
    private float xStartPosition;
    public bool facingRight = true;


    void Start()
    {
        xStartPosition = transform.position.x;
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up*180);
    }
    void Update()
    {
        if ((speed < 0 && transform.position.x < xStartPosition) || (speed > 0 && transform.position.x > xStartPosition + distance))
        {
            Flip();
            speed *= -1;
        }
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

}
