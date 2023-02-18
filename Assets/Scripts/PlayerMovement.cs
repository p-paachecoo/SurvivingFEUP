using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public Camera camera;
    Vector2 mousePosition;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 look = mousePosition - rb.position;

        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}
