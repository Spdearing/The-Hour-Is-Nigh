using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardData : MonoBehaviour
{
    [SerializeField] private Card card;
    [SerializeField] private int value;
    [SerializeField] private string suit;
    [SerializeField] private Sprite suitSprite;
    [SerializeField] private Image suitImage;
    [SerializeField] private TMP_Text rankImage1;
    [SerializeField] private TMP_Text rankImage2;


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
        rankImage1 = GameObject.Find("Rank1").GetComponent<TMP_Text>();
        rankImage2 = GameObject.Find("Rank2").GetComponent<TMP_Text>();
        suitImage = GameObject.Find("SuitImage").GetComponent<Image>();
        card = cardData;
        value = card.GetValue();
        Debug.Log(value);
        Debug.Log(rankImage1);
        Debug.Log(rankImage2);
        rankImage1.text = value.ToString();
        rankImage2.text = value.ToString();
        suit = card.GetSuit();
        suitSprite = card.ReturnSuitImage();
        suitImage.sprite = suitSprite; 
    }
}
