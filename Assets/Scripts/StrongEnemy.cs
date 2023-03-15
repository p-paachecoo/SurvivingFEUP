using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : MonoBehaviour
{

    private Transform playerTransform;
    private GameObject player;
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;

    private float bulletCounter = 0f;

    public GameObject twentyMarkPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            bulletCounter += 0.5f;
            if(bulletCounter == 20)
            {
                GameObject twentyMark = (GameObject) Instantiate(twentyMarkPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Pencil")
        {
            bulletCounter += 2f;
            if(bulletCounter == 20)
            {
                GameObject twentyMark = (GameObject) Instantiate(twentyMarkPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "LifeCollectible") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "ScoreCollectible") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "FireRatePowerup") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "SpeedPowerup") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "MapCollider1") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "MapCollider2") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "EnemyBullet") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "StrongEnemy") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "Enemy") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();

        Transform mapCollider1 = GameObject.FindWithTag("MapCollider1").transform;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), mapCollider1.GetComponent<Collider2D>());

        Transform mapCollider2 = GameObject.FindWithTag("MapCollider2").transform;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), mapCollider2.GetComponent<Collider2D>());

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
        
        if(GameObject.FindWithTag("SpeedPowerup") != null)
        {
            Transform speedPowerup = GameObject.FindWithTag("SpeedPowerup").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), speedPowerup.GetComponent<Collider2D>());
        }
    }

    void IgnoreCollisionsSearch()
    {
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
        
        if(GameObject.FindWithTag("SpeedPowerup") != null)
        {
            Transform speedPowerup = GameObject.FindWithTag("SpeedPowerup").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), speedPowerup.GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        IgnoreCollisionsSearch();
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

