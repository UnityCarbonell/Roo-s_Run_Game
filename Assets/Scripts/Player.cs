using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpForce;
    public int speedMov;
    public bool touchingFloor = false;

    public Animator rooAnimator;
    public float deathDuration;

    Rigidbody2D rb;

    public GameEvents ge;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();  
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
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator DeathAnimation()
    {
        rooAnimator.SetTrigger("Dead");
        yield return new WaitForSeconds(deathDuration);
        IsDead();
    }

    void IsDead()
    {
        Debug.Log("Roo is dead");
        ge.RooDying();
    }
}
