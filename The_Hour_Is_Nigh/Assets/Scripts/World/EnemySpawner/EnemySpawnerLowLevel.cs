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
    [SerializeField] private Transform spawnLocation1;
    [SerializeField] private Transform spawnLocation2;
    [SerializeField] private Transform spawnLocation3;

    public delegate void SpawnBlobs();
    public static event SpawnBlobs spawnBlob;

    // Start is called before the first frame update
    void Start()
    {
        smallBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\EnemyOne");
        mediumBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\EnemyTwo");
        largeBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\EnemyThree");
        spawnLocation1 = GameObject.Find("SpawnLocationOne").GetComponent<Transform>();
        spawnLocation2 = GameObject.Find("SpawnLocationTwo").GetComponent<Transform>();
        CheckBlobEnemyLocation(this.gameObject.name);
    }

    public IEnumerator SpawnBlob(GameObject blobEnemy, Vector3 spawnLocation)
    {
        yield return new WaitForSeconds(2);
        GameObject blobEnemyInstance = Instantiate(blobEnemy, spawnLocation, Quaternion.identity);
        blobEnemy.AddComponent<BlobBehavior>();
        blobEnemy.AddComponent<EnemyHealthManager>();
        GameManager.Instance.BlobDied = false;
    }

    public void CheckBlobEnemyLocation(string spawnLocation)
    {
        switch(spawnLocation)
        {
            case "SpawnLocationOne":
                {
                    StartCoroutine(SpawnBlob(smallBlob, spawnLocation1.transform.position));
                }
                break;
            case "SpawnLocationTwo":
                {
                    
                    StartCoroutine(SpawnBlob(mediumBlob, spawnLocation2.transform.position));
                }
                break;

            default:
                Debug.LogWarning("Invalid spawn location: " + spawnLocation);
                break;
        }
    }

    public void RespawnEnemy(string enemyName)
    {
        Vector3 enemySpawnLocation = gameObject.transform.position;

        switch (enemyName)
        {
            case "EnemyOne(Clone)":
                {
                    StartCoroutine(SpawnBlob(smallBlob, spawnLocation1.transform.position));
                }
                break;
            case "EnemyTwo(Clone)":
                {
                    enemySpawnLocation = gameObject.transform.position;
                    StartCoroutine(SpawnBlob(mediumBlob, spawnLocation2.transform.position));
                }
                break;

            default:
                Debug.LogWarning("Invalid spawn location: " + enemyName);
                break;
        }
    }


    public GameObject ReturnSmallBlob()
    {
        return smallBlob;
    }

    public GameObject ReturnMediumBlob()
    {
        return mediumBlob;
    }

    public GameObject ReturnLargeBlob()
    {
        return largeBlob;   
    }
}



