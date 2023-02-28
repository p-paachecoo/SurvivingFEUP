using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Unity Setup Field")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 0f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        GameObject enemy = (GameObject) Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
