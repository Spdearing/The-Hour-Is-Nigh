using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    [SerializeField] private Card card;
    [SerializeField] private int value;
    [SerializeField] private string suit;
    [SerializeField] private Sprite suitImage;


    [SerializeField] BlackJackManager blackJackManager;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardData(Card cardData)
    {
        card = cardData;

        value = card.GetValue();
        suit = card.GetSuit();
        suitImage = card.ReturnSuitImage();
    }
}
