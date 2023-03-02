using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{
    private float x;
    private float y;
    private float z = 0;
    private Vector3 pos;

    [Header("Unity Setup Field")]
    public GameObject collectiblePrefab_Life;
    public GameObject collectiblePrefab_Score;


    void Start()
    {
        InvokeRepeating("CreateCollectible", 0f, 15f);
    }

    void CreateCollectible()
    {
        x = Random.Range(-30, 30);
        y = Random.Range(-30, 30);
        pos = new Vector3(x, y, z);
        transform.position = pos;

        if(this.gameObject.name == "SpawnPoint (Collectible Life)")
        {
            GameObject collectible = (GameObject) Instantiate(collectiblePrefab_Life, transform.position, transform.rotation);
        }
        else if(this.gameObject.name == "SpawnPoint (Collectible Score)")
        {
            GameObject collectible = (GameObject) Instantiate(collectiblePrefab_Score, transform.position, transform.rotation);
        }

    }
}
