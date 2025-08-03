using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]

public class Card : ScriptableObject
{
    [SerializeField] private Dictionary<string, Sprite> deckImages = new Dictionary<string, Sprite>();


    [SerializeField] private Image Image;
    [SerializeField] private string suit;
    [SerializeField] private int value;
    [SerializeField] private Sprite suitImage;
    [SerializeField] private GameObject card;

    public string GetSuit()
    {
        return this.suit;
    }

    public int GetValue()
    {
        return this.value;
    }

    public void SetCardValue(int value)
    {
        this.value = value;
    }

    public void SetCardSuit(string suit)
    {
        this.suit = suit;
    }

    public void SetSuitImage(string suit)
    {
        suitImage = deckImages[suit];    
    }

    public Sprite ReturnSuitImage()
    {
        return this.suitImage;
    }

    public Dictionary<string, Sprite> DeckImages()
    {
        return deckImages;
    }
}


