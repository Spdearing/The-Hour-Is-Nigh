using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BJ_Deck : MonoBehaviour
{
    [SerializeField] public Dictionary<string,List<string>> suits = new Dictionary<string, List<string>>(); 


    // Start is called before the first frame update
    void Start()
    {
        suits["Hearts"] = new List<string> { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        suits["Spades"] = new List<string> { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        suits["Diamonds"] = new List<string> { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        suits["Clubs"] = new List<string> { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        Debug.Log(string.Join(", ", suits["Hearts"]));
    }

    public void ShuffleDeck()
    {

    }
}
