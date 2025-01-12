using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string playerName;
    private int playerExperience;
    private int levelUp;
    private int playerHealth;
    private int playerMaxHealth;

    public Player(string playerName, int playerExperience,int levelUp, int playerHealth, int playerMaxHealth)
    {
        this.playerName = playerName;
        this.playerExperience = playerExperience;
        this.levelUp = levelUp;
        this.playerHealth = playerHealth;
        this.playerMaxHealth = playerMaxHealth;
    }

    public void PlayerExperienceIncrease(int enemyHealth)
    {
        this.playerExperience += Mathf.RoundToInt(enemyHealth/10);
        Debug.Log("Payer gained" + enemyHealth/10 + " experience");
    }

    public string PlayerName
    {
        get
        {
            return playerName; 
        }
        set
        { 
            playerName = value;
        }
    }

    public int PlayerExperience
    {
        get
        {
            return playerExperience;
        }
        set
        {
            playerExperience = value;
        }
    }

    public int LevelUp
    {
        get
        {
            return levelUp;
        }
        set
        {
            levelUp = value;
        }
    }

    public int PlayerHealth
    {
        get
        {
            return playerHealth;
        }
        set
        {
            playerHealth = value;
        }
    }

    public int PlayerMaxHealth
    {
        get
        {
            return playerMaxHealth;
        }
        set
        {
            playerMaxHealth = value;
        }
    }
}
