using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackManager : MonoBehaviour
{
    [Header("Instances of essential elements")]
    [SerializeField] private PlayersHand playerHand;
    [SerializeField] private Dealer dealer;
    [SerializeField] private Card card;
    [SerializeField] private BJ_Deck deck;
    [SerializeField] private Dictionary<string, List<string>> shuffledDeck;
    [SerializeField] private Dictionary<string, Image> suitSymbols;


    [Header("Card Lists")]
    [SerializeField] private List<int> ranks;
    [SerializeField] private List<string> suits;


    // Start is called before the first frame update
    void Start()
    {
        playerHand = new PlayersHand();
        card = ScriptableObject.CreateInstance<Card>();
        dealer = new Dealer();
        deck = GameObject.Find("Deck").GetComponent<BJ_Deck>();
        shuffledDeck = deck.ConstructDeck();
        AddToCardSprites();
        FormDeck();
        DealPlayerCards();
        ShowPlayersHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetCardImages()
    {

    }

    public void AddToCardSprites()
    {
        
        Image[] suitImages = Resources.LoadAll<Image>("Suit Images.png"); // Correct path and type
        suitSymbols = card.DeckImages(); //get card from the scriptable object

        if (suitImages.Length >= 4)
        {
            suitSymbols.Add("Spade", suitImages[0]);
            suitSymbols.Add("Diamond", suitImages[1]);
            suitSymbols.Add("Club", suitImages[2]);
            suitSymbols.Add("Hearts", suitImages[3]);
        }
        else
        {
            Debug.LogWarning("Not enough sprites loaded from Suit Images.png!");
        }
        Debug.Log(3);
    }

    public void FormDeck()
    {
        int faceCardValue;
        int cardsDrawn = 0;
        Debug.Log(1);
        

        while(cardsDrawn < 52)
        {
            Card newCard = ScriptableObject.Instantiate(card as Card);
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

                cardsDrawn += 1;

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
    }

    public void DealRandomCard()
    {
        playerHand.InitialHand(suits[0], ranks[0]);
    }

    public void DealPlayerCards()
    {
        Debug.Log(2);
        for (int i = 0; i < 2; i++)
        {
            playerHand.InitialHand(suits[0], ranks[0]);
            Debug.Log("Suit Keys: " + string.Join(", ", suitSymbols.Keys));

            foreach (string suit in suitSymbols.Keys )
            {
                if(suit == suits[0])
                {
                    card.SetSuitImage(suit);
                    Debug.Log("card image should be " + suit);
                }
            }
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

