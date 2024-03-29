using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    private float x;
    private float y;
    private float z = 0;
    private Vector3 pos;

    [Header("Unity Setup Field")]
    public GameObject powerUpPrefab_FireRate;
    public GameObject powerUpPrefab_Speed;


    void Start()
    {
        InvokeRepeating("CreatePowerUp", 0f, 15f);
    }

    void CreatePowerUp()
    {
        x = Random.Range(-30, 30);
        y = Random.Range(-30, 30);
        pos = new Vector3(x, y, z);
        transform.position = pos;

        if(this.gameObject.name == "SpawnPoint (Powerup FireRate)")
        {
            GameObject powerUp = (GameObject) Instantiate(powerUpPrefab_FireRate, transform.position, transform.rotation);
        }
        else if(this.gameObject.name == "SpawnPoint (Powerup Speed)")
        {
            GameObject powerUp = (GameObject) Instantiate(powerUpPrefab_Speed, transform.position, transform.rotation);
        }

    }
}
