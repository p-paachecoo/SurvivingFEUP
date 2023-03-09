using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectible : MonoBehaviour
{
    void Start()
    {
        if(GameObject.FindWithTag("Enemy") != null)
        {
            Transform enemyNormal = GameObject.FindWithTag("Enemy").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), enemyNormal.GetComponent<Collider2D>());
        }

        if(GameObject.FindWithTag("StrongEnemy") != null)
        {
            Transform enemyStrong = GameObject.FindWithTag("StrongEnemy").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), enemyStrong.GetComponent<Collider2D>());
        }
    }

    void FixedUpdate()
    {
        if(GameObject.FindWithTag("Enemy") != null)
        {
            Transform enemyNormal = GameObject.FindWithTag("Enemy").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), enemyNormal.GetComponent<Collider2D>());
        }

        if(GameObject.FindWithTag("StrongEnemy") != null)
        {
            Transform enemyStrong = GameObject.FindWithTag("StrongEnemy").transform;
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), enemyStrong.GetComponent<Collider2D>());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
