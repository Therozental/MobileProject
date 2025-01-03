using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject shopPopup;
    public GameObject leveUpPopup;
    public GameObject internetPopup;
    public Deck levelUpCards;

    public void GetNewCards(Deck playerDeck)
    {
        for (int i = 0; i < 5; i++)
        {
            //get a random card from the general deck
            int randomIndex = Random.Range(0, levelUpCards.cards.Count);
            Card randomCard = levelUpCards.cards[randomIndex];
            
            //put them in the player deck
            playerDeck.cards.Add(randomCard);
            Debug.Log("new card added to you Deck!");
        }
        
    }
}
