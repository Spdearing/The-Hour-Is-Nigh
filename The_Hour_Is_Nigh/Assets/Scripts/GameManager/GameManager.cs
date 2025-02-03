using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private bool blobDied;

    [Header("Scripts")]
    [SerializeField] private EnemySpawnerLowLevel blobSpawn;

    [Header("Enemy")]
    [SerializeField] private GameObject smallBlob;
    [SerializeField] private GameObject mediumBlob;
    [SerializeField] private GameObject largeBlob;

    private void Awake()
    {
        if (Instance != null && Instance != this){
            Destroy(gameObject); 
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        blobSpawn = GameObject.Find("SpawnLocation").GetComponent<EnemySpawnerLowLevel>();
        smallBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint1");
        mediumBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint2");
        largeBlob = Resources.Load<GameObject>("Prefabs\\Enemies\\ReferencePoint3");
    }

    public void SpawnBlobAfterDeath()
    {
        if (blobDied){
            blobSpawn.StartCoroutine(blobSpawn.SpawnBlob(smallBlob,blobSpawn.transform.position));
        }return;
    }


    public bool BlobDied
    {
        get
        {
            return blobDied;
        }
        set
        {
            blobDied = value;
        }
    }
}
