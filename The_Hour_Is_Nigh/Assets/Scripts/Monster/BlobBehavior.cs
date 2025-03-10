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
        Debug.Log(gameObject.name);
        gameObject.name = blob.EnemyName;
        gameObject.tag = "Enemy";
        blobHealth = blob.EnemyHealth;
        Debug.Log(gameObject.name);
        blobMaxHealth = blob.EnemyMaxHealth;
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        enemyHealthManager = this.gameObject.GetComponent<EnemyHealthManager>();
        blobDied = false;
        
    }

    public void CheckEnemy(string enemyName)
    {
        switch (enemyName)
        {
            case "EnemyOne(Clone)":
                {
                    blob = new Enemy("Weak Blob", 25, 25, 2);
                }
                break;
            case "EnemyTwo(Clone)":
                {
                    blob = new Enemy("Medium Blob", 35, 35, 5);
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
