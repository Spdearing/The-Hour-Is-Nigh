using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlackJackManager : MonoBehaviour
{
    [Header("Instances of essential elements")]

    [SerializeField] private PlayersHand playerHand;
    [SerializeField] private Dealer dealer;
    [SerializeField] private Card card;
    [SerializeField] private BJ_Deck deck;
    [SerializeField] private Dictionary<string, List<string>> shuffledDeck;

    [SerializeField] private List<int> dealersDeck;
    [SerializeField] private List<string> suits;

    // Start is called before the first frame update
    void Start()
    {
        playerHand = new PlayersHand();
        dealer = new Dealer();
        deck = new BJ_Deck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FormDeck()
    {
        shuffledDeck = deck.ConstructDeck();
        int faceCardValue;

        for (int i = 0; i <= 51 ; i++)
        {
            int randomSuit = Random.Range(0, shuffledDeck.Count);
            var dictionaryKey = shuffledDeck.ElementAt(randomSuit);
            string suit = dictionaryKey.Key;
            suits.Add(suit);
            List<string> cardSpotInList = dictionaryKey.Value;
            int randomValue = Random.Range(0, cardSpotInList.Count);
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
                dealersDeck.Add(faceCardValue);
            shuffledDeck.Remove(cardSpotInList[randomValue]);
        }
    }
}
