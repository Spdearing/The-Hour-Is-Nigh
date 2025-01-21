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
    [SerializeField] int playerLevel;

    [Header("Scripts")]
    [SerializeField] PlayerStats playerStats;
    void Start()
    {
        playerXpBar = GameObject.Find("PlayerXP").GetComponent<Image>();
        playerStats = GetComponent<PlayerStats>();
        playerExperience = playerStats.PlayerExperience;
        playerLevel = playerStats.Level;
        playerLevelUpThreshold = playerStats.LevelUpNumber;
        playerXpBar.fillAmount = playerExperience;
    }

    public void UpdatePlayerExperienceBar()
    {
        playerXpBar.fillAmount = playerExperience;
    }
}
