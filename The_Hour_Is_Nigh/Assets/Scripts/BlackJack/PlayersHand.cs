using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersHand
{
    private List<int> playerHand = new List<int>();
    private int handValue;


    public int GetHandValue()
    {
        return handValue;
    }

    public List<int> GetPlayersHand()
    {
        return playerHand;
    }

    public void Hit(int card)
    {
        playerHand.Add(card);
    }

    public int CalculateScore()
    {
        handValue = 0;
        handValue += playerHand.Sum();
        return handValue;
    }
}
