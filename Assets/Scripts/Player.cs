using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpForce;
    public int speedMov;
    public bool touchingFloor = false;
    //public bool dead;

    Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //dead = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && touchingFloor)
        {
            touchingFloor = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }

        rb.velocity = new Vector2(speedMov, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col1)
    {
        touchingFloor = true;
        if (col1.collider.gameObject.tag == "Obstacule")
        {
            // dead = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
