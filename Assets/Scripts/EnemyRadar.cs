using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{

    private GameObject[] enemies;
    public Transform closestEnemy; 
    public bool enemyContact;

    void Start()
    {
        closestEnemy = null;
    }

    void Update()
    {
        closest = getClosestEnemy();
        closestEnemy.gameObject.GetComponent<SpriteRenderer>();
    }

    public Transform getClosestEnemy()
    {
        enemies = GameObject.FindGameObjectWithTag("Enemy");
        float distance = Mathf.Infinity;
        Transform trs = null;

        foreach (GameObject g in enemies)
        {
            float currentDistance = Vector3.Distance(transform.position, g.transform.position);

            if(currentDistance < distance)
            {
                distance = currentDistance;
                trs = g.transform;
            }
        }

        return trs;
    }
}
