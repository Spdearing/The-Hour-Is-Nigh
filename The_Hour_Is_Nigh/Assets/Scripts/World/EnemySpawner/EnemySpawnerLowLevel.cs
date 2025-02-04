using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLowLevel : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject smallBlob;
    [SerializeField] private GameObject mediumBlob;
    [SerializeField] private GameObject largeBlob;

    [Header("Enemy Spawn Location")]
    [SerializeField] private Vector3 spawnLocation1;

    public delegate void SpawnBlobs();
    public static event SpawnBlobs spawnBlob;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation1 = this.gameObject.transform.position;
        smallBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint1");
        mediumBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint2");
        largeBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint3");
        StartCoroutine(SpawnBlob(smallBlob,spawnLocation1));
    }

    public IEnumerator SpawnBlob(GameObject blobEnemy, Vector3 spawnLocation)
    {
        yield return new WaitForSeconds(2);
        GameObject blobEnemyInstance = Instantiate(blobEnemy, spawnLocation, Quaternion.identity);
        blobEnemyInstance.AddComponent<BlobBehavior>();
        blobEnemyInstance.AddComponent<EnemyHealthManager>();
        GameManager.Instance.BlobDied = false;
    }
    
}
