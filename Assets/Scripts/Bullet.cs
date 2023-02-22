using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 15f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        Vector3 dir = new Vector3(); 
        float distanceThisFrame = speed * Time.deltaTime;

        if(target != null)
        {
            dir = target.position - transform.position;
        } else
        {   
            // aqui sofre um ligeiro desvio de posição. necessário corrigir
            transform.Translate(transform.position.normalized * distanceThisFrame, Space.World);
        }

        if(transform != null)
        {
            if(target != null)
            {
                Vector3 t = target.transform.position;
                t.z = 0f;
                Vector3 objectPos = transform.position;
                t.x = t.x - objectPos.x;
                t.y = t.y - objectPos.y;
                float angle = (Mathf.Atan2(t.y, t.x) * Mathf.Rad2Deg) - 90f;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }
}
