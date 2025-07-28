using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BlackJackManager : MonoBehaviour
{
    [Header("Instances of essential elements")]

    [SerializeField] private PlayersHand playerHand;
    [SerializeField] private Dealer dealer;
    [SerializeField] private Card card;
    [SerializeField] private BJ_Deck deck;
    [SerializeField] private Dictionary<string, List<string>> shuffledDeck;

    [SerializeField] private List<int> ranks;
    [SerializeField] private List<string> suits;

    // Start is called before the first frame update
    void Start()
    {
        playerHand = new PlayersHand();
        dealer = new Dealer();
        deck = GameObject.Find("Deck").GetComponent<BJ_Deck>();
        shuffledDeck = deck.ConstructDeck();
        FormDeck();
        DealPlayerCards();
        ShowPlayersHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FormDeck()
    {
        int faceCardValue;
        int cardsDrawn = 0;


        while(cardsDrawn < 52)
        {
            int randomSuit = UnityEngine.Random.Range(0, shuffledDeck.Count);
            
            var dictionaryKey = shuffledDeck.ElementAt(randomSuit);
            string suit = dictionaryKey.Key;

            
            List<string> cardSpotInList = dictionaryKey.Value;
            int randomValue = UnityEngine.Random.Range(0, cardSpotInList.Count);

            if (cardSpotInList.Count != 0)
            {
                
                string value = cardSpotInList[randomValue];

                if (value == "A")
                {
                    faceCardValue = 11;
                }
                else if (value == "J" || value == "Q" || value == "K")
                {
                    faceCardValue = 10;
                }
                else
                {
                    faceCardValue = int.Parse(value);
                }

                ranks.Add(faceCardValue);
                suits.Add(suit);
                shuffledDeck[suit].Remove(value);

                Debug.Log("Number of cards left in suit: " + cardSpotInList.Count);

                Debug.Log("Value to be removed: " +  suit + value);

                cardsDrawn += 1;
                Debug.Log("Cards Drawn: " + cardsDrawn);

                foreach (string rank in cardSpotInList)
                {
                    Debug.Log($"Suit: {suit} → Cards: {string.Join(", ", rank)}");
                }

            }
        }
    }

    public List<int> GetRanks()
    {
        return ranks;
    }

    public List<string> GetSuits()
    {
        return suits;
    }

    public void RemoveDeltCardsFromLists()
    {
        suits.Remove(suits[0]);
        ranks.Remove(ranks[0]);
        Debug.Log("Removing Card");
    }

    public void DealRandomCard()
    {
        playerHand.InitialHand(suits[0], ranks[0]);
    }

    public void DealPlayerCards()
    {
        for (int i = 0; i < 2; i++)
        {
            playerHand.InitialHand(suits[0], ranks[0]);
        }
    }

    public void ShowPlayersHand()
    {
        List<Tuple<string,int>> playersCards;
        playersCards = playerHand.GetPlayersHand();
        Debug.Log(playersCards[0]);
        Debug.Log(playersCards[1]);
    }
}

