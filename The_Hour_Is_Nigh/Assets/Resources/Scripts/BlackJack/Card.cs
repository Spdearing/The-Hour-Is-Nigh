using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]

public class Card : ScriptableObject
{
    [SerializeField] private string suit;
    [SerializeField] private int value;
    [SerializeField] private GameObject card;

    public string GetSuit()
    {
        return this.suit;
    }

    public int GetValue()
    {
        return this.value;
    }
}

        
