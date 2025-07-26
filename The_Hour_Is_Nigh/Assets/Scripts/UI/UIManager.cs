using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Text UI Elements")]
    [SerializeField] private TMP_Text playersMoney;
    [SerializeField] private TMP_Text nameOfGame;
    [SerializeField] private TMP_Text playersScore;
    [SerializeField] private TMP_Text dealersScore;

    [Header("Game Name")]
    [SerializeField] private Dictionary<int, string> gameName = new Dictionary<int, string>()
    {
        {1 , "Black Jack" },
        {2 , "Texas Hold'em" },
        {3, "Exploding 9s" }

    };


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
