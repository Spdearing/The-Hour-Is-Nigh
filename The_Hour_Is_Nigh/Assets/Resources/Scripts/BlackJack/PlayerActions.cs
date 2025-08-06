using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private PlayersHand playerHand;
    [SerializeField] private int handValue;

    // Start is called before the first frame update
    void Start()
    {
        if(playerHand == null)
        {
            playerHand = BlackJackManager.Instance.ReturnPlayerHandInstance();
        }
    }

    // Update is called once per frame
    void Update()
    {
         TestCalculate();
    }

    public void Hit()
    {
        
    }

    public void TestCalculate()
    {
        if ((Input.GetKey(KeyCode.C)))
        {
            playerHand.CalculateScore();
            handValue = playerHand.GetHandValue();
            Debug.Log(handValue);
        }
    }
}
