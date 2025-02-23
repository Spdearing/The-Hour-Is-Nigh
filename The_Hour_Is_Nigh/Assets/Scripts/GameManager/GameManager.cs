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
        blobSpawn = GameObject.Find("SpawnLocationOne").GetComponent<EnemySpawnerLowLevel>();
    }

    public void SpawnBlobAfterDeath(string blob)
    {
        if (blobDied)
        {
            blobSpawn.RespawnEnemy(blob);
        }
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
