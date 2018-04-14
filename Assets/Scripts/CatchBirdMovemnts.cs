using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBirdMovemnts : MonoBehaviour
{

    public float speed;
    public float distance;
    private float xStartPosition;
    bool facingLeft = true;
    bool invoked = false;
    public Transform carryLocation; // this is empty gameobject as a child of player, object will be carried on this position
    Transform currentItem = null;
    public bool pagavau = false;
    Vector2 saveVelocity;
    public GameObject explosion;

    void Start()
    {
        Flip();
        xStartPosition = transform.position.x;
    }
    void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(Vector3.up * 180);
    }
    void Update()
    {
        if(!pagavau)
        {
            if ((speed < 0 && transform.position.x < xStartPosition) || (speed > 0 && transform.position.x > xStartPosition + distance))
            {
                Flip();
                speed *= -1;
            }
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            //
            transform.position = new Vector2(transform.position.x + (speed*4) * Time.deltaTime, transform.position.y + speed * Time.deltaTime);
            // Make sure invoked once
            if(!invoked)
            {
                Invoke("EndFly", 3);
                invoked = true;
            }
        }  
    }
    void EndFly()
    {
        //Change object back to dynamic 
        currentItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //Change isTrigger back to true
        currentItem.GetComponent<PolygonCollider2D>().isTrigger = true;
        // Restore velocity
        currentItem.GetComponent<Rigidbody2D>().velocity = saveVelocity;
        // Add some force
        currentItem.GetComponent<Rigidbody2D>().AddForce(currentItem.transform.right * 500 + currentItem.transform.up * 500);
        // remove as child
        currentItem.parent = null;

        //set position near player
        currentItem.position = transform.GetComponent<SpriteRenderer>().bounds.max;

        // release reference
        currentItem = null;
        // Destroy(gameObject, 0.5f);
        pagavau = false;
        Instantiate(explosion, gameObject.transform.position, transform.rotation = Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (facingLeft)
        {
            Flip();
            speed *= -1;
        }
        // pickup if it has tag "Item" and we are not carrying anything
        if (other.CompareTag("Bullet") && currentItem == null)
        {
            currentItem = other.transform;
            // Save object velocity to restore later
            saveVelocity = currentItem.GetComponent<Rigidbody2D>().velocity;
            // Change trigger to not collide while in carry mode
            currentItem.GetComponent<PolygonCollider2D>().isTrigger = false;
            // take reference to that collided object
            currentItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
     
            // move it to carrying point
            currentItem.position = gameObject.transform.position;

            // make it as a child of player, so it moves along with player
            currentItem.parent = transform;
            // Make bird fly faster with ball
            //transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            pagavau = true;

        }
    }

}
