using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooting : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    private float fireCountdown = 0f;
    public float range = 20f;
    public float fireRate = 5f;

    private GameObject bullet;

    [Header("Unity Setup Fields")]
    public Transform firePoint;
    public GameObject bulletPrefab;


    void Start()
    {
        InvokeRepeating ("UpdateTarget", 0f, 0.25f);
    }

    void Update()
    {
        if(target == null) 
            return;

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bullet = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet b = bullet.GetComponent<Bullet>();

        if(b != null)
            b.Seek(target);
    }

    void UpdateTarget()
    {

        GameObject[] enemies_normal = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] enemies_strong = GameObject.FindGameObjectsWithTag("StrongEnemy");
        GameObject[] enemies = enemies_normal.Concat(enemies_strong).ToArray();
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
}
