using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
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
    [SerializeField] private List<GameObject> playingCards;
    [SerializeField] private List<Card> cardDeck;

    [Header("Transforms")]
    [SerializeField] private Transform deckLocation;
    [SerializeField] private Transform playersHandLocation;
    [SerializeField] private Transform dealersHandLocation;


    // Start is called before the first frame update
    void Start()
    {
        deckLocation = GameObject.Find("DeckLocation").GetComponent<Transform>();
        playersHandLocation = GameObject.Find("PlayersHandLocation").GetComponent<Transform>();
        dealersHandLocation = GameObject.Find("DealersHandLocation").GetComponent<Transform>();
        cardDeck = new List<Card>();
        card = ScriptableObject.CreateInstance<Card>();
        playerHand = new PlayersHand();
        dealer = new Dealer();
        deck = GameObject.Find("Deck").GetComponent<BJ_Deck>();
        playingCards = new List<GameObject>();
        cardObject = Resources.Load<GameObject>("Prefabs/Cards/Card");
        shuffledDeck = deck.ConstructDeck();

        GetAllPlayingCards();  
        FormDeck();
        DealPlayerCards();
        ShowPlayersHand();
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

    private void GetAllPlayingCards()
    {
        GameObject[] cards = Resources.LoadAll<GameObject>("Prefabs/Cards/Deck01");

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<CardData>() == null)
            {
                GameObject cardInstance = Instantiate(cards[i], deckLocation.position, Quaternion.Euler(90,0,0));
                cardInstance.AddComponent<CardData>();
                //cardInstance.AddComponent<Rigidbody>();
                //cardInstance.AddComponent<BoxCollider>();
                playingCards.Add(cardInstance);
                
            }
            else
            {
                RemoveAllInstancesOfScript<CardData>(cards[i]);
                i--;
            }
            var newYPosition = deckLocation.transform.position.y;
            newYPosition += .01f;
            deckLocation.position = new Vector3(deckLocation.position.x, newYPosition, deckLocation.position.z);
        }
    }

    void RemoveAllInstancesOfScript<Script>(GameObject go) where Script : MonoBehaviour
    {
        Script[] scriptsToRemove = go.GetComponents<Script>();

        foreach (Script scriptInstance in scriptsToRemove)
        {
            DestroyImmediate(scriptInstance, true);
        }
    }

    public void AddToCardSprites(Dictionary<string, Sprite> suits)
    {
        //Get card images
        Sprite[] suitImages = Resources.LoadAll<Sprite>("Images/Suit Images"); // Correct path and type

        if (suitImages.Length >= 4)
        {
            suits.Add("Heart", suitImages[3]);
            suits.Add("Spade", suitImages[2]);
            suits.Add("Diamond", suitImages[1]);
            suits.Add("Club", suitImages[0]);
        }
        else
        {
            Debug.LogWarning("Not enough sprites loaded from Suit Images.png!");
        }
    }

    public void FormDeck()
    {
        int faceCardValue;
        int cardsDrawn = 0;
       
        while (cardsDrawn < 52)//As long as the cardsDrawn is under 52 it will make a deck
        {
            
            Card newCardInstance = ScriptableObject.CreateInstance<Card>();
            AddToCardSprites(newCardInstance.DeckImages());
            //GameObject newCard = Instantiate(cardObject, deckLocation.position, Quaternion.identity);
            //CardData data = newCard.GetComponent<CardData>();
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
                //data.SetCardData(newCardInstance);
                cardDeck.Add(newCardInstance);
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
        playerHand.Hit(cardDeck[0].GetSuit(), cardDeck[0].GetValue());
    }

    public void DealPlayerCards()
    {

        for (int i = 0; i < 2; i++)
        {
            if (cardDeck.Count > 0)
            {
                List<Tuple<string, int>> playersCards = playerHand.GetPlayersHand();
                playersCards.Add(new Tuple<string, int>(cardDeck[0].GetSuit(), cardDeck[0].GetValue()));

                cardDeck.RemoveAt(0);
            }
        }
    }

    public void ShowPlayersHand()
    {
        List<Tuple<string,int>> playersCards;
        playersCards = playerHand.GetPlayersHand();
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
    public List<Tuple<string,int>> ReturnPlayersHand()
    {
        return this.playerHand.GetPlayersHand();
    }
    public PlayersHand ReturnPlayerHandInstance()
    {
        return this.playerHand;
    }
}

