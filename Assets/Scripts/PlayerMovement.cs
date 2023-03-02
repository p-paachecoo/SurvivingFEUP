using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;
    Vector2 movement;

    new public Camera camera;

    public Shooting shooting;

    private Transform target;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if(rb.position.x >= 30)
        {
            rb.position = new Vector2(30, rb.position.y);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else if(rb.position.x <= -30)
        {
            rb.position = new Vector2(-30, rb.position.y);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else if(rb.position.y >= 30)
        {
            rb.position = new Vector2(rb.position.x, 30);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else if(rb.position.y <= -30)
        {
            rb.position = new Vector2(rb.position.x, -30);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FireRatePowerup")
        {
            shooting.fireRate = 10f;
        } else if(collision.gameObject.tag == "LifeCollectible")
        {

        } else if(collision.gameObject.tag == "ScoreCollectible")
        {

        }
    }

}
