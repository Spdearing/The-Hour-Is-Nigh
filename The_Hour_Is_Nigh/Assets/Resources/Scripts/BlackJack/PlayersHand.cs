using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersHand
{
    [SerializeField] private List<Tuple<string, int>> playersCards = new List<Tuple<string, int>>();
    [SerializeField] private int handValue;

    public int GetHandValue()
    {
        return handValue;
    }

    public List<Tuple<string, int>> GetPlayersHand()
    {
        return playersCards;
    }

    public void InitialHand(string suit, int cardValue)
    {
        playersCards.Add(new Tuple<string, int>(suit, cardValue));
        BlackJackManager.Instance.RemoveDeltCardsFromLists();
    }

    public void Hit(string suit, int cardValue)
    {
        playersCards.Add(new Tuple<string, int>(suit, cardValue));
        BlackJackManager.Instance.DealPlayerCards();   
    }
    public void Stay()
    {
        CalculateScore();
    }

    public int CalculateScore()
    {
        handValue = 0;

        Debug.Log($"Number of cards in hand: {playersCards.Count}");

        foreach (var card in playersCards)
        {
            handValue += card.Item2;
            Debug.Log("card item 1 " + card.Item1);
            Debug.Log("card item 2 " + card.Item2);
        }
        Debug.Log(handValue);
        return handValue;
        
    }
}
