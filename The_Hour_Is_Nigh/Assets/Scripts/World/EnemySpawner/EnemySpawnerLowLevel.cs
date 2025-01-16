using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLowLevel : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject blobEnemy;

    [Header("Blob Behavior Script")]
    [SerializeField] private BlobBehavior blobBehavior;

    [Header("Enemy Spawn Location")]
    [SerializeField] private Vector3 spawnLocation;



    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = this.gameObject.transform.position;
        blobEnemy = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint1");
        blobBehavior = Resources.Load<BlobBehavior>("Scripts\\Monster");
        SpawnBlobs();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBlobs()
    {
        
        GameObject blobEnemyInstance = Instantiate(blobEnemy, spawnLocation, Quaternion.identity);
        blobEnemyInstance.AddComponent<BlobBehavior>();
        blobEnemyInstance.AddComponent<EnemyHealthManager>();
    }
}
