using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float x;
    private float y;
    private float z = 0;
    private Vector3 pos;

    [Header("Unity Setup Field")]
    public GameObject enemyPrefab;
    public GameObject strongEnemyPrefab;
    public Transform spawnPoint;

    void Start()
    {
        InvokeRepeating("CreateEnemy", 0f, 0.75f);
        InvokeRepeating("CreateStrongEnemy", 20f, 20f);
    }

    void CreateEnemy()
    {

        if(this.gameObject.name == "SpawnPoint (Enemy1)")
        {
            x = Random.Range(-50, 50);
            y = -100;
            pos = new Vector3(x, y, z);
            spawnPoint.position = pos;

            GameObject enemy = (GameObject) Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else if(this.gameObject.name == "SpawnPoint (Enemy2)")
        {
            x = -100;
            y = Random.Range(-50, 50);
            pos = new Vector3(x, y, z);
            spawnPoint.position = pos;

            GameObject enemy = (GameObject) Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else if(this.gameObject.name == "SpawnPoint (Enemy3)")
        {
            x = Random.Range(-50, 50);
            y = 100;
            pos = new Vector3(x, y, z);
            spawnPoint.position = pos;

            GameObject enemy = (GameObject) Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else if(this.gameObject.name == "SpawnPoint (Enemy4)")
        {
            x = 100;
            y = Random.Range(-50, 50);
            pos = new Vector3(x, y, z);
            transform.position = pos;

            GameObject enemy = (GameObject) Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    void CreateStrongEnemy()
    {

        if(this.gameObject.name == "SpawnPoint (Enemy1)")
        {
            x = Random.Range(-50, 50);
            y = -100;
            pos = new Vector3(x, y, z);
            spawnPoint.position = pos;

            GameObject enemy = (GameObject) Instantiate(strongEnemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else if(this.gameObject.name == "SpawnPoint (Enemy2)")
        {
            x = -100;
            y = Random.Range(-50, 50);
            pos = new Vector3(x, y, z);
            spawnPoint.position = pos;

            GameObject enemy = (GameObject) Instantiate(strongEnemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else if(this.gameObject.name == "SpawnPoint (Enemy3)")
        {
            x = Random.Range(-50, 50);
            y = 100;
            pos = new Vector3(x, y, z);
            spawnPoint.position = pos;

            GameObject enemy = (GameObject) Instantiate(strongEnemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else if(this.gameObject.name == "SpawnPoint (Enemy4)")
        {
            x = 100;
            y = Random.Range(-50, 50);
            pos = new Vector3(x, y, z);
            transform.position = pos;

            GameObject enemy = (GameObject) Instantiate(strongEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
