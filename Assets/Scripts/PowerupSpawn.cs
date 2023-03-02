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
    public GameObject powerUpPrefab;

    void Start()
    {
        InvokeRepeating("CreatePowerUp", 0f, 10f);
    }

    void CreatePowerUp()
    {
        x = Random.Range(-30, 30);
        y = Random.Range(-30, 30);
        pos = new Vector3(x, y, z);
        transform.position = pos;

        GameObject powerUp = (GameObject) Instantiate(powerUpPrefab, transform.position, transform.rotation);
    }
}
