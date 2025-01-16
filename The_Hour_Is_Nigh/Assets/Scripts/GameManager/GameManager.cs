using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private bool blobDied;

    [Header("Scripts")]
    [SerializeField] private EnemySpawnerLowLevel blobSpawn;

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBlobAfterDeath()
    {
        if (blobDied)
        {
            blobSpawn.StartCoroutine(blobSpawn.SpawnBlob());
        }
        return;
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
