using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardData : MonoBehaviour
{
    [SerializeField] private Card card;
    [SerializeField] private GameObject cardObject;
    [SerializeField] private int value;
    [SerializeField] private string suit;
    [SerializeField] private Sprite suitSprite;
    [SerializeField] private Image suitImage;
    [SerializeField] private Image suitImage2;
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
        Transform canvas = transform.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("CardData: Canvas not found!");
            return;
        }

        rankImage1 = canvas.Find("Rank1")?.GetComponent<TMP_Text>();
        rankImage2 = canvas.Find("Rank2")?.GetComponent<TMP_Text>();
        suitImage = canvas.Find("SuitImage1")?.GetComponent<Image>();
        suitImage2 = canvas.Find("SuitImage2")?.GetComponent<Image>();

        if (rankImage1 == null || rankImage2 == null || suitImage == null || suitImage2 == null)
        {
            Debug.LogError("CardData: One or more UI elements not found or missing components!");
            return;
        }

        card = cardData;
        value = card.GetValue();
        suit = card.GetSuit();
        suitSprite = card.ReturnSuitImage();

        rankImage1.text = value.ToString();
        rankImage2.text = value.ToString();
        suitImage.sprite = suitSprite;
        suitImage2.sprite = suitSprite;
    }
}
