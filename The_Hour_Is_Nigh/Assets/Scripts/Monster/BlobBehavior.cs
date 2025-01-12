using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBehavior : MonoBehaviour
{

    [SerializeField] private int blobHealth;
    [SerializeField] private int blobMaxHealth;
    [SerializeField] private PlayerStats playerStats;


    // Start is called before the first frame update
    void Start()
    {
        Enemy blob = new Enemy("Blob", 25, 25, 2);
        gameObject.name = blob.EnemyName;
        gameObject.tag = "Enemy";
        blobHealth = blob.EnemyHealth;
        blobMaxHealth = blob.EnemyMaxHealth;
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlobDies()
    {
        if (blobHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.PlayerExperienceIncrease(blobMaxHealth);
        }
        else
        {
            return;
        }
    }

    public void TakeDamage(int playerAttackDamage)
    {
        blobHealth -= playerAttackDamage;
    }
}
