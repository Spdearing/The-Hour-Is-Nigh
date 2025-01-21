using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExperienceManager : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] Image playerXpBar;


    [Header("Level Text")]
    [SerializeField] TMP_Text levelText;

    [Header("Player Experience")]
    [SerializeField] int playerExperience;
    [SerializeField] int playerLevelUpThreshold;
    [SerializeField] int playerLevel;

    [Header("Scripts")]
    [SerializeField] PlayerStats playerStats;
    void Start()
    {
        levelText = GameObject.Find("LevelText").GetComponent<TMP_Text>();
        playerXpBar = GameObject.Find("PlayerXP").GetComponent<Image>();
        playerStats = GetComponent<PlayerStats>();
        playerExperience = playerStats.PlayerExperience;
        playerLevel = playerStats.Level;
        playerLevelUpThreshold = playerStats.LevelUpNumber;
        playerXpBar.fillAmount = playerExperience;
        levelText.text = playerLevel.ToString();
    }

    public void UpdatePlayerExperienceBar(int playerExperience, int playerLevelUpThreshold)
    {
        playerXpBar.fillAmount = playerExperience / (float)playerLevelUpThreshold;
        levelText.text = playerStats.Level.ToString();
    }
}
