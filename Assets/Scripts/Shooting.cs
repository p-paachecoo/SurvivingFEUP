using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    private float fireCountdown = 0f;
    public float range = 40f;
    public float fireRate = 1f;

    private GameObject bullet;

    [Header("Unity Setup Fields")]
    public Transform firePoint;
    public GameObject bulletPrefab;


    void Start()
    {
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
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

        // necessário corrigir rotação, está mal
        // Vector3 direction = target.position - transform.position;
        // Quaternion look = Quaternion.LookRotation(direction);
        // Vector3 rotation = look.eulerAngles;
        // firePoint.rotation = Quaternion.Euler(0f, 0f, rotation.z);

        // Vector2 direction = target.position - transform.position;
        // Vector2 unity_direction = direction / Mathf.Sqrt(Mathf.Pow(direction.x,2) - Mathf.Pow(direction.y,2));
        // Vector2 i = new Vector2(1,0);
        // float angle = Mathf.Acos(Vector2.Dot(unity_direction, i));
        // // float look = Mathf.Atan(direction);
        // // firePoint.rotation.x = look;
        // firePoint.transform.Rotate(0f, 0f, angle, Space.World);



        if(b != null)
            b.Seek(target);
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
