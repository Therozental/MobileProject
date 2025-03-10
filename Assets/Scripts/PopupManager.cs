using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject shopPopup;
    public GameObject leveUpPopup;
    public GameObject internetPopup;
    public Deck levelUpCards;
    public GameObject PlayerDeckGameObject;

    public void GetNewCards(Deck playerDeck)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject cardPrefab = GeneralDeck.instance.GetRandomCard();
            GameObject card = Instantiate(cardPrefab, Vector2.zero, Quaternion.identity);

            card.transform.SetParent(playerDeck.transform);
            card.GetComponent<RectTransform>().localScale = Vector3.one;
            card.SetActive(false);
            playerDeck.cards.Add(card.GetComponent<Card>());
        }
    }
}
/*
 for (int i = 0; i < 5; i++)
   {

       //get a random card from the general deck
       int randomIndex = Random.Range(0, levelUpCards.cards.Count);
       Card randomCard = levelUpCards.cards[randomIndex];

       //create card in scene view - put them in the player deck


       playerDeck.cards.Add(randomCard);

       Debug.Log("new card added to you Deck!");
   }

*/