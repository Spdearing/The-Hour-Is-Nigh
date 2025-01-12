using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private string enemyName;
    private int enemyMaxHealth;
    private int enemyHealth;
    private int enemyAttackDamage;


    public Enemy(string enemyName, int enemyMaxHealth, int enemyHealth, int enemyAttackDamage)
    {
        this.enemyName = enemyName;
        this.enemyMaxHealth = enemyMaxHealth;
        this.enemyHealth = enemyHealth;
        this.enemyAttackDamage = enemyAttackDamage;
    }




    public void EnemyDies()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
        }
    }

    public string EnemyName
    {
        get
        {
            return enemyName;
        }
        set
        {
            enemyName = value;
        }
    }

    public int EnemyHealth
    {
        get
        {
            return enemyHealth;
        }
        set
        {
            enemyHealth = value;
        }
        
    }

    public int EnemyMaxHealth
    {
        get
        {
            return enemyMaxHealth;
        }
        set
        {
            enemyMaxHealth = value;
        }
    }

    public int EnemyAttackDamage
    {
        get
        {
            return enemyAttackDamage;
        }
        set
        {
            enemyAttackDamage = value;
        }
    }
}
