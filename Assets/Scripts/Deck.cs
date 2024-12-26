using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public List<Card> DiscardPile = new List<Card>();


    public void Shuffle() // Shuffle method to randomize the order of cards in the cards.
    {
        for (int i = 0; i < cards.Count; i++)
        {
            // Get a random index.
            int randomIndex = Random.Range(0, cards.Count);

            //Swap between the random index and the i
            (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]);
        }

        Debug.Log("Cards Shuffled");
    }

    public Card DrawTopCard()
    {
        // the top card of the deck
        Card topCard = cards[0];

        // remove the top card from the cards pile
        cards.RemoveAt(0);
        Debug.Log($"card drawn {topCard}");
        return topCard;
    }

    public void PlayerRemove3Cards() // if both cards has the same value, take out 3 cards from each deck and try again
    {
        for (int i = 0; i < 3; i++)
        {
            //remove the first card from the player pile
            Card removedPlayerCard = DrawTopCard();

            // add the card to the player discard pile
            DiscardPile.Add(removedPlayerCard);

            Debug.Log("Player removed 3 cards");
        }
        //***have some cool animation each card removal***
    }

    public void CPURemove3Cards()
    {
        for (int i = 0; i < 3; i++)
        {
            // remove the first card from the cpu pile
            Card removedCpuCard = DrawTopCard();

            // put the card last in the cpu deck
            cards.Insert(cards.Count, removedCpuCard);

            Debug.Log("CPU removed 3 cards");
        }
        //***have some cool animation each card removal***
    }
}