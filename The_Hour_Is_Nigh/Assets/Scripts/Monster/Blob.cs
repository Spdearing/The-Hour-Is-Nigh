using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob
{
    private string enemyName;
    private int enemyMaxHealth;
    private int enemyHealth;
    private int enemyAttackDamage;


    public Blob(string enemyName, int enemyMaxHealth, int enemyHealth, int enemyAttackDamage)
    {
        this.enemyName = enemyName;
        this.enemyMaxHealth = enemyMaxHealth;
        this.enemyHealth = enemyHealth;
        this.enemyAttackDamage = enemyAttackDamage;
    }


    public void TakeDamage(int playerAttackDamage)
    {
        this.enemyHealth -= playerAttackDamage;
    }

    public void EnemyDies()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
        }
    }
}
