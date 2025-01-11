using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLowLevel : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject blobEnemy;

    [Header("Enemy Spawn Location")]
    [SerializeField] private Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBlobs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBlobs()
    {
        Blob blob = new Blob("Bob", 25, 25, 2);
        GameObject blobEnemyInstance = Instantiate(blobEnemy, spawnLocation, Quaternion.identity);
    }
}
