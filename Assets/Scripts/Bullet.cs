using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 15f;
    private Vector3 aux_dir = new Vector3();

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            target = null;
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

        }
    }
}