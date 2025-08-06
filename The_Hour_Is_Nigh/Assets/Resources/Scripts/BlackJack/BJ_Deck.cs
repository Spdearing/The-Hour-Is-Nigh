using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BJ_Deck : MonoBehaviour
{
    [SerializeField] private Dictionary<string,List<string>> deck = new Dictionary<string, List<string>>(); 


    //this is where the black jack deck is created
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
        deck["Heart"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        deck["Spade"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        deck["Diamond"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        deck["Club"] = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    }
}
