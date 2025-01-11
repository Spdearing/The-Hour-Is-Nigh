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

    public Player(string playerName, int playerExperience, int playerHealth, int playerMaxHealth)
    {
        this.playerName = playerName;
        this.playerExperience = playerExperience;
        this.playerHealth = playerHealth;
        this.playerMaxHealth = playerMaxHealth;
    }

    public void PlayerExperienceIncrease(int enemyHealth)
    {
        this.playerExperience += enemyHealth/10;
        Debug.Log("Payer gained" + enemyHealth/10 + " experience");
    }
}
