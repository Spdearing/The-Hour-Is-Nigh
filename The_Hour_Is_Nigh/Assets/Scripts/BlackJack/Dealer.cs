using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dealer
{
    private List<int> dealerHand = new List<int>();
    private int handValue;


    public int GetHandValue()
    {
        return handValue;
    }

    public List<int> GetDealersHand()
    {
        return dealerHand;
    }

    public void Hit(int card)
    {
        dealerHand.Add(card);
    }

    public int CalculateScore()
    {
        handValue = 0;
        handValue += dealerHand.Sum();
        return handValue;
    }
}