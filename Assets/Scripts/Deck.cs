using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> DiscardPile = new List<Card>();

    // Shuffle method to randomize the order of cards in the deck.
    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int randomIndex = Random.Range(0, deck.Count); // Get a random index.
            (deck[i], deck[randomIndex]) = (deck[randomIndex], deck[i]); //Swap between the random index and the i
        }

        Debug.Log("Cards Shuffled");
    }

    public Card DrawTopCard()
    {
        Card topCard = deck[0];
        deck.RemoveAt(0); // remove card from the player pile
        return topCard;
    }
/*
    public void Remove3Cards() // take out 3 cards from each deck
    {
        //have some cool animation
        deck.RemoveRange(0, 3);
    }
    */

    /*
    public void DiscardCard(Card card)
    {
        DiscardPile.Add(card);
        //get the card from the player/cpu
    }
    */
}