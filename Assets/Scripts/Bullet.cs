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
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }
}
