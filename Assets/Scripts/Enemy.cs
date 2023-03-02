using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform playerTransform;
    private GameObject player;
    public float moveSpeed = 7.5f;
    private Vector2 movement;
    private Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();

        if(GameObject.FindWithTag("LifeCollectible") != null)
        {
            Transform lifeCollectible = GameObject.FindWithTag("LifeCollectible").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), lifeCollectible.GetComponent<Collider2D>());
        }

        if(GameObject.FindWithTag("ScoreCollectible") != null)
        {
            Transform scoreCollectible = GameObject.FindWithTag("ScoreCollectible").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), scoreCollectible.GetComponent<Collider2D>());
        }

        if(GameObject.FindWithTag("FireRatePowerup") != null)
        {
            Transform fireRatePowerup = GameObject.FindWithTag("FireRatePowerup").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), fireRatePowerup.GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate(){
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
