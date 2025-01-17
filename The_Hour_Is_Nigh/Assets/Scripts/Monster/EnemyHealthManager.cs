using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    [Header("Image")]
    [SerializeField] Image enemyHealthBar;

    [Header("EnemyHealth")]
    [SerializeField] int enemyHealth;
    [SerializeField] int enemyMaxHealth;

    [Header("Scripts")]
    [SerializeField] BlobBehavior blobBehavior;





    // Start is called before the first frame update
    void Start()
    {
        enemyHealthBar = GameObject.Find("EnemyHealth").GetComponent<Image>();
        blobBehavior = this.gameObject.GetComponent<BlobBehavior>();
        enemyHealth = blobBehavior.EnemyHealth;
        enemyMaxHealth = blobBehavior.EnemyMaxHealth;
        enemyHealthBar.fillAmount = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEnemyHealth(int enemyCurrentHealth)
    {
        enemyHealth = enemyCurrentHealth;
        enemyHealthBar.fillAmount = enemyCurrentHealth / 100.0f;
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
}
