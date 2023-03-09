using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilGun : MonoBehaviour
{

private Transform target;
    public float speed = 15f;
    private Vector3 aux_dir = new Vector3();

    Score scoreScript;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            target = null;
            scoreScript.AddScore(1);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "StrongEnemy")
        {
            Destroy(gameObject);
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Start()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

        Transform mapCollider1 = GameObject.FindWithTag("MapCollider1").transform;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), mapCollider1.GetComponent<Collider2D>());

        Transform mapCollider2 = GameObject.FindWithTag("MapCollider2").transform;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), mapCollider2.GetComponent<Collider2D>());
        
        scoreScript = GameObject.Find("Player").GetComponent<Score>();

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
        Vector3 dir = new Vector3(); 
        float distanceThisFrame = speed * Time.deltaTime;

        if(transform != null)
        {
            if(target != null)
            {
                dir = target.position - transform.position;
                aux_dir = dir;
                Vector3 t = target.transform.position;
                t.z = 0f;
                Vector3 objectPos = transform.position;
                t.x = t.x - objectPos.x;
                t.y = t.y - objectPos.y;
                float angle = (Mathf.Atan2(t.y, t.x) * Mathf.Rad2Deg) - 90f;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                
                transform.Translate(dir.normalized * distanceThisFrame, Space.World);

            } else if(target == null)
            {
                transform.Translate(aux_dir.normalized * distanceThisFrame, Space.World);
            }

            if(transform.position.x >= 100 || transform.position.x <= -100 || 
                transform.position.y >= 100 || transform.position.y <= -100)
            {
                Destroy(gameObject);
            }

        }
    }

}
