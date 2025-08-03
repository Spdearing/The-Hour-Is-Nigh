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
    public static BlackJackManager Instance;

    [Header("Instances of essential elements")]
    [SerializeField] private PlayersHand playerHand;
    [SerializeField] private Dealer dealer;
    [SerializeField] private Card card;
    [SerializeField] private Card playingCard;
    [SerializeField] private BJ_Deck deck;
    [SerializeField] private GameObject cardObject;
    [SerializeField] private Dictionary<string, List<string>> shuffledDeck;
    [SerializeField] private Dictionary<string, Sprite> suitSymbols;


    [Header("Card Lists")]
    [SerializeField] private List<int> ranks;
    [SerializeField] private List<string> suits;
    [SerializeField] private List<Card> cardDeck;


    // Start is called before the first frame update
    void Start()
    {
        cardDeck = new List<Card>();
        card = ScriptableObject.CreateInstance<Card>(); 
        playerHand = new PlayersHand();
        dealer = new Dealer();
        deck = GameObject.Find("Deck").GetComponent<BJ_Deck>();
        cardObject = Resources.Load<GameObject>("Prefabs/Cards/Card");
        shuffledDeck = deck.ConstructDeck();
        
        FormDeck();
        DealPlayerCards();
        ShowPlayersHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of BlackJackManager detected. Destroying duplicate.");
            Destroy(gameObject);
        }
    }

    public void AddToCardSprites()
    {
        
        Sprite[] suitImages = Resources.LoadAll<Sprite>("Images/Suit Images"); // Correct path and type
        suitSymbols = card.DeckImages(); //get card from the scriptable object
        Debug.Log(suitImages.Length);

        if (suitImages.Length >= 4)
        {
            Debug.Log("Populating Image Array");
            suitSymbols.Add("Spade", suitImages[0]);
            suitSymbols.Add("Diamond", suitImages[1]);
            suitSymbols.Add("Club", suitImages[2]);
            suitSymbols.Add("Heart", suitImages[3]);
            Debug.Log("Image Array is Populated");
            Debug.Log(suitSymbols.Count);
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
        AddToCardSprites();

        while (cardsDrawn < 52)
        {
            Card newCardInstance = ScriptableObject.CreateInstance<Card>();
            GameObject newCard = Instantiate(cardObject, new Vector3(0,0,0), Quaternion.identity);
            CardData data = newCard.GetComponent<CardData>();
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

                newCardInstance.SetCardValue(faceCardValue);
                newCardInstance.SetCardSuit(suit);
                newCardInstance.SetSuitImage(suit);
                Debug.Log($"Created card - Suit: {newCardInstance.GetSuit()}, Value: {newCardInstance.GetValue()}");
                cardDeck.Add(newCardInstance);
                data.SetCardData(newCardInstance);
                ranks.Add(faceCardValue);
                suits.Add(suit);
                shuffledDeck[suit].Remove(value);
               

                cardsDrawn += 1;

            }
        }
    }


    public void RemoveDeltCardsFromLists()
    {
        if (cardDeck.Count > 0)
            cardDeck.RemoveAt(0);
    }

    public void DealRandomCard()
    {
        Card topCard = cardDeck[0];
        playerHand.InitialHand(topCard.GetSuit(), topCard.GetValue());
    }

    public void DealPlayerCards()
    {
        Debug.Log(2);
        for (int i = 0; i < 2; i++)
        {
            if (cardDeck.Count > 0)
            {
                Card drawnCard = cardDeck[0];
                playerHand.InitialHand(drawnCard.GetSuit(), drawnCard.GetValue());
                Debug.Log($"Dealt: {drawnCard.GetSuit()} {drawnCard.GetValue()}");

                // Display card image (if needed)
                if (suitSymbols.TryGetValue(drawnCard.GetSuit(), out Sprite suitSprite))
                {
                    card.SetSuitImage(drawnCard.GetSuit());
                    Debug.Log("card image should be " + drawnCard.GetSuit());
                }

                cardDeck.RemoveAt(0);
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


    public List<int> GetRanks()
    {
        return ranks;
    }

    public List<string> GetSuits()
    {
        return suits;
    }

    public Card GetPlayingCard()
    {
     
            return this.playingCard; 
        
    }
}

