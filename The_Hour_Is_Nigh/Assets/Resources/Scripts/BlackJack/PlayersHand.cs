using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersHand
{
    [SerializeField] private List<Tuple<string, int>> playersCards = new List<Tuple<string, int>>();
    private BlackJackManager blackJackManager = GameObject.Find("BlackJackManager").GetComponent<BlackJackManager>();
    private int handValue;

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
        blackJackManager.RemoveDeltCardsFromLists();
    }

    public void Hit(string suit, int cardValue)
    {
        playersCards.Add(new Tuple<string, int>(suit, cardValue));
        blackJackManager.DealPlayerCards();
        
    }

    public int CalculateScore()
    {
        handValue = 0;
        foreach (var card in playersCards)
        {
            handValue += card.Item2;
        }
        return handValue;
    }
}
