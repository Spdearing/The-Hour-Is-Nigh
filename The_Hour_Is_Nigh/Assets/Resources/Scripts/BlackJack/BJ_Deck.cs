using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BJ_Deck : MonoBehaviour
{
    [SerializeField] private Dictionary<string,List<string>> deck = new Dictionary<string, List<string>>(); 


    // Start is called before the first frame update
    void Start()
    {
        InitializeDeck();
    }

    public Dictionary<string, List<string>> ConstructDeck()
    {
        return  this.deck;
    }

    public void InitializeDeck()
    {
        deck["Hearts"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        deck["Spades"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        deck["Diamonds"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        deck["Clubs"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    }
}
