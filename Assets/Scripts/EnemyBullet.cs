using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    private Vector3 dir;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "LifeCollectible") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "ScoreCollectible") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "FireRatePowerup") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "SpeedPowerup") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "Enemy") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "StrongEnemy") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "MapCollider1") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        } else if (collision.gameObject.tag == "MapCollider2") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {        
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

        if(GameObject.FindWithTag("Enemy") != null)
        {
            Transform enemy = GameObject.FindWithTag("Enemy").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        }
    
        if(GameObject.FindWithTag("StrongEnemy") != null)
        {
            Transform strong_enemy = GameObject.FindWithTag("StrongEnemy").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), strong_enemy.GetComponent<Collider2D>());
        }

        dir = new Vector3(); 

        if(transform != null)
        {
            if(target != null)
            {
                dir = target.position - transform.position;
                Vector3 t = target.transform.position;
                t.z = 0f;
                Vector3 objectPos = transform.position;
                t.x = t.x - objectPos.x;
                t.y = t.y - objectPos.y;
                float angle = (Mathf.Atan2(t.y, t.x) * Mathf.Rad2Deg) - 90f;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                
            }
        }
    }

    void Update()
    {
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        if(transform.position.x >= 100 || transform.position.x <= -100 || 
            transform.position.y >= 100 || transform.position.y <= -100)
        {
            Destroy(gameObject);
        }
    }
}
