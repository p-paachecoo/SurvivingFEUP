using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyShooting : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    private float fireCountdown = 0f;
    public float fireRate = 1f;

    private GameObject bullet;

    [Header("Unity Setup Fields")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
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
        EnemyBullet b = bullet.GetComponent<EnemyBullet>();

        if(b != null)
            b.Seek(target);
    }
}
