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
        spawnLocation = this.gameObject.transform.position;
        blobEnemy = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint1");
        SpawnBlobs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBlobs()
    {
        Enemy blob = new Enemy("Blob", 25, 25, 2);
        GameObject blobEnemyInstance = Instantiate(blobEnemy, spawnLocation, Quaternion.identity);
        blobEnemyInstance.name = blob.EnemyName;
    }
}
