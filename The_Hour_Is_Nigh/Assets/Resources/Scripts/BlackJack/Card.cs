using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]

public class Card : ScriptableObject
{

    [SerializeField] private Dictionary<string, Image> deckImages = new Dictionary<string, Image>();


    [SerializeField] private string suit;
    [SerializeField] private int value;
    [SerializeField] private Image suitImage;
    [SerializeField] private GameObject card;

    public string GetSuit()
    {
        return this.suit;
    }

    public int GetValue()
    {
        return this.value;
    }

    public void SetSuitImage(string suit)
    {
            
    }
}


