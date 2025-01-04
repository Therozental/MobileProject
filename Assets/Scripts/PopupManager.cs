using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject shopPopup;
    public GameObject leveUpPopup;
    public GameObject internetPopup;
    public Deck levelUpCards;
    public GameObject PlayerPilePlacement;

    public void GetNewCards(Deck playerDeck)
    {
        for (int i = 0; i < 5; i++)
        {
            //get a random card from the general deck
            int randomIndex = Random.Range(0, levelUpCards.cards.Count);
            Card randomCard = levelUpCards.cards[randomIndex];
            
            //put them in the player deck
            PlaceCardToPlayerDeck(randomCard, PlayerPilePlacement);
            playerDeck.cards.Add(randomCard);
            // instantiate card and set parent it to the playerdeck
            Debug.Log("new card added to you Deck!");
        }
        
    }
    
    public void PlaceCardToPlayerDeck(Card currentCard, GameObject cardPilePlacement)
    {
        currentCard.transform.SetParent(cardPilePlacement.transform);
        currentCard.transform.position = cardPilePlacement.transform.position;
    }
}
