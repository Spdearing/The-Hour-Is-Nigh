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
    [SerializeField] private int levelUp;
    [SerializeField] private int levelUpOverlap;



    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player("Sam", 0, 1, 5, 25, 25);
        playerHealth = player.PlayerHealth;
        playerMaxHealth = player.PlayerMaxHealth;
        playerExperience = player.PlayerExperience;
        levelUp = player.LevelUp;
        level = player.Level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerExperienceIncrease(int enemyHealth)
    {
        this.playerExperience += Mathf.RoundToInt(enemyHealth + 100);
        Debug.Log("Payer gained " + enemyHealth/10 + " experience");


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
}
