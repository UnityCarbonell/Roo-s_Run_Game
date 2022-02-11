using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpForce;
    public int speedMov;
    public bool touchingFloor = false;

    public Animator rooAnimator;
    public float deathDuration;

    Rigidbody2D rb;
    GameObject roo;

    public GameEvents ge;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        roo = this.gameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown("space") && touchingFloor)
        {
            touchingFloor = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }
        roo.transform.Translate(new Vector3(speedMov * Time.deltaTime, 0, 0));
    }
    private void OnCollisionEnter2D(Collision2D col1)
    {
        touchingFloor = true;
        if (col1.collider.gameObject.tag == "Obstacule")
        {
            speedMov = 0;
            CameraScript.Instance.ShakeCam(5, 5, 2);
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
