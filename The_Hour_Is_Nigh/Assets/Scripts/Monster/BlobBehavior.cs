using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlobBehavior : MonoBehaviour
{
    [Header("Blob Stats")]
    [SerializeField] private Enemy blob;
    [SerializeField] private int blobHealth;
    [SerializeField] private int blobMaxHealth;

    [Header("Scripts")]
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private EnemySpawnerLowLevel blobSpawner;
    [SerializeField] private EnemyHealthManager enemyHealthManager;

    [Header("Bools")]
    [SerializeField] private bool blobDied;


    // Start is called before the first frame update
    void Start()
    {
        CheckEnemy(gameObject.name);
        gameObject.name = blob.EnemyName;
        gameObject.tag = "Enemy";
        blobHealth = blob.EnemyHealth;
        blobMaxHealth = blob.EnemyMaxHealth;
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        blobSpawner = GameObject.Find("SpawnLocationOne").GetComponent<EnemySpawnerLowLevel>();
        enemyHealthManager = this.gameObject.GetComponent<EnemyHealthManager>();
        blobDied = false;
        
    }

    public void CheckEnemy(string enemyName)
    {
        switch (enemyName)
        {
            case "ReferencePoint1(Clone)":
                {
                    blob = new Enemy("Weak Blob", 20, 25, 2);
                }
                break;
            case "ReferencePoint2(Clone)":
                {
                    blob = new Enemy("Medium Blob", 35, 25, 2);
                }
                break;

            default:
                Debug.LogWarning("Invalid spawn location: " + enemyName);
                break;
        }
    }


    public void BlobDies()
    {
        if (blobHealth <= 0){
            playerStats.PlayerExperienceIncrease(blobMaxHealth);
            playerStats.LevelUp();
            GameManager.Instance.BlobDied = true;
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }

    public void BlobWillRespawn()
    {
        if (blobDied == true)
        {
            Invoke("SpawnBlobs", 3);
        }
        return;
    }
    public void TakeDamage(int playerAttackDamage)
    {
        blobHealth -= playerAttackDamage;
        enemyHealthManager.UpdateEnemyHealth(blobHealth);
    }

    public int EnemyHealth
    {
        get
        {
            return blobHealth;
        }set
        {
            blobHealth = value;
        }
    }

    public int EnemyMaxHealth
    {
        get
        {
            return blobMaxHealth;
        }set
        {
            blobMaxHealth = value;
        }
    }
}
