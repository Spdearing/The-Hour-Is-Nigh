using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerMaxHealth;
    [SerializeField] private int playerExperience;
    [SerializeField] private int level;
    [SerializeField] private int levelUp { get; set; }
    [SerializeField] private int levelUpOverlap;

    [Header("Script")]
    [SerializeField] PlayerExperienceManager experienceManager;



    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player("Sam", 0, 1, 5, 25, 25);
        playerHealth = player.PlayerHealth;
        playerMaxHealth = player.PlayerMaxHealth;
        playerExperience = player.PlayerExperience;
        levelUp = player.LevelUp;
        level = player.Level;
        experienceManager = GetComponent<PlayerExperienceManager>();
    }


    public void PlayerExperienceIncrease(int enemyHealth)
    {
        this.playerExperience += Mathf.RoundToInt(enemyHealth + 100);
        experienceManager.UpdatePlayerExperienceBar();
    }

    public void LevelUp()
    {
        if (playerExperience >= levelUp)
        {
            level += 1;
            levelUpOverlap = playerExperience - levelUp;
            StatIncreases();
            LevelUp();
        }
        return;
    }

    public void StatIncreases()
    {
        playerMaxHealth += 5;
        levelUp += 25;
        this.playerExperience = levelUpOverlap;
    }

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    public int LevelUpNumber
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
}
