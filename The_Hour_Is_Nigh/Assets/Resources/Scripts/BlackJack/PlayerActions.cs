using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private PlayersHand playerHand;

    // Start is called before the first frame update
    void Start()
    {
        playerHand = new PlayersHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard()
    {
        
    }
}
