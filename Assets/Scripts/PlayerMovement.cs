using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Public Fields
    public float speed = 12.5f;
    public Rigidbody2D rb;
    Vector2 movement;

    new public Camera camera;

    public Shooting shooting;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameManager gameManager;

    public Score score;

    public Animator animator;

    public SpriteRenderer playerSprite;


    // Private Fields
    private float shootingTime = 0f;
    private float speedTime = 0f;

    private Transform target;

    private Shooting gunStudy;
    private PG_Shooting pencilGun;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        gunStudy = GetComponent<Shooting>();
        pencilGun = GetComponent<PG_Shooting>();
        pencilGun.enabled = false;
        gunStudy.enabled = true;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            if(gunStudy.enabled)
            {
                gunStudy.enabled = false;
                pencilGun.enabled = true;
                shootingTime = 0f;
                pencilGun.fireRate = 1f;
            }
            else
            {
                pencilGun.enabled = false;
                gunStudy.enabled = true;
                shootingTime = 0f;
                gunStudy.fireRate = 5f;
            }
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x < 0)
        {
            playerSprite.flipX = true;
        }
        else if(movement.x > 0)
        {
            playerSprite.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(movement.x), Mathf.Abs(movement.y)));

        if(currentHealth <= 0)
        {
            gameManager.EndGame();
        }
    }

    void FixedUpdate()
    {
        if(rb.position.x > 60)
        {
            rb.position = new Vector2(60, rb.position.y);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else if(rb.position.x < -60)
        {
            rb.position = new Vector2(-60, rb.position.y);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else if(rb.position.y > 50)
        {
            rb.position = new Vector2(rb.position.x, 50);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else if(rb.position.y < -50)
        {
            rb.position = new Vector2(rb.position.x, -50);
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        } else
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }

        if(gunStudy.enabled)
        {
            if(gunStudy.fireRate == 15f)
            {
                shootingTime += 1;

                if(shootingTime == 600f)
                {
                    shootingTime = 0f;
                    gunStudy.fireRate = 5f;
                }
            }
        }
        else
        {
            if(pencilGun.fireRate == 3f)
            {
                shootingTime += 1;

                if(shootingTime == 600f)
                {
                    shootingTime = 0f;
                    pencilGun.fireRate = 1f;
                }
            }
        }

        if(speed == 20f)
        {
            speedTime += 1;

            if(speedTime == 400f)
            {
                speedTime = 0f;
                speed = 12.5f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FireRatePowerup")
        {
            if(gunStudy.enabled)
            {
                gunStudy.fireRate = 15f;
                shootingTime = 0f;
            }
            else
            {
                pencilGun.fireRate = 3f;
                shootingTime = 0f;
            }
        } 
        else if(collision.gameObject.tag == "SpeedPowerup")
        {
            speed = 20f;
            speedTime = 0f;
        } 
        else if(collision.gameObject.tag == "LifeCollectible")
        {
            currentHealth += 10;
            healthBar.SetHealth(currentHealth);
        } 
        else if(collision.gameObject.tag == "ScoreCollectible")
        {
            score.AddScore(20);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            currentHealth -= 2;
            healthBar.SetHealth(currentHealth);
        }
        else if(collision.gameObject.tag == "StrongEnemy")
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
        }
    }

}
