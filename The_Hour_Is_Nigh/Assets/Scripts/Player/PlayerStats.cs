using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerMaxHealth;
    [SerializeField] private int playerExperience;
    [SerializeField] private int levelUp;



    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player("Sam", 0, 1, 10, 25, 25);
        playerHealth = player.PlayerHealth;
        playerMaxHealth = player.PlayerMaxHealth;
        playerExperience = player.PlayerExperience;
        levelUp = player.LevelUp;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerExperienceIncrease(int enemyHealth)
    {
        this.playerExperience += Mathf.RoundToInt(enemyHealth/10);
        Debug.Log("Payer gained" + enemyHealth/10 + " experience");

        if(playerExperience >= levelUp)
        {
            Debug.Log("Player Has Leveled Up");
        }
    }

    public void StatIncreases()
    {
        playerMaxHealth += 5;
        levelUp += 25;
    }
}
