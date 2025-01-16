using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLowLevel : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject blobEnemy;


    [Header("Enemy Spawn Location")]
    [SerializeField] private Vector3 spawnLocation;

    public delegate void SpawnBlobs();
    public static event SpawnBlobs spawnBlob;
    



    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = this.gameObject.transform.position;
        blobEnemy = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint1");
        StartCoroutine(SpawnBlob());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator SpawnBlob()
    {
        yield return new WaitForSeconds(2);
        GameObject blobEnemyInstance = Instantiate(blobEnemy, spawnLocation, Quaternion.identity);
        blobEnemyInstance.AddComponent<BlobBehavior>();
        blobEnemyInstance.AddComponent<EnemyHealthManager>();
        GameManager.Instance.BlobDied = false;
    }
}
