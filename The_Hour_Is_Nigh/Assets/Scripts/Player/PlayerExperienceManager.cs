using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperienceManager : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] Image playerXpBar;

    [Header("Player Experience")]
    [SerializeField] int playerExperience;
    [SerializeField] int playerLevelUpThreshold;

    [Header("Scripts")]
    [SerializeField] PlayerStats playerStats;
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        //playerExperience = playerStats.level;
        //enemyMaxHealth = blobBehavior.EnemyMaxHealth;
        //enemyHealthBar.fillAmount = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
