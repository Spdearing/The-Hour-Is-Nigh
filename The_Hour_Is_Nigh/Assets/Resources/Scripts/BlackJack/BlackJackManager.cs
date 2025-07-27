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

    [SerializeField] private List<int> dealersDeck;
    [SerializeField] private List<string> suits;

    // Start is called before the first frame update
    void Start()
    {
        playerHand = new PlayersHand();
        dealer = new Dealer();
        deck = GameObject.Find("Deck").GetComponent<BJ_Deck>();
        FormDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FormDeck()
    {
        shuffledDeck = deck.ConstructDeck();
        
        int faceCardValue;
        int cardsDrawn = 0;


        while(cardsDrawn < 52)
        {
            int randomSuit = Random.Range(0, shuffledDeck.Count);
            
            var dictionaryKey = shuffledDeck.ElementAt(randomSuit);
            string suit = dictionaryKey.Key;

            
            List<string> cardSpotInList = dictionaryKey.Value;
            int randomValue = Random.Range(0, cardSpotInList.Count);

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

                dealersDeck.Add(faceCardValue);
                suits.Add(suit);
                shuffledDeck[suit].Remove(value);
                Debug.Log("Suit " + suit);
                Debug.Log("Rank " + value);

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
}
