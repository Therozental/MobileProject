using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> playerDeck = new List<Card>();
    public List<Card> cpuDeck = new List<Card>();

    public void CreateDeck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        for (int value = 2; value <= 14; value++) // Ranks: 2 (2) to 14 (ace)
        {
            foreach (string suit in suits)
            {
                deck.Add(new Card(value, suit));
            }
        }

        Shuffle();
    }

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

    public void DealCards()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            if (i % 2 == 0) // Even index: assign to player
            {
                playerDeck.Add(deck[i]);
            }
            else if (i % 2 != 0) // Odd index: assign to CPU
            {
                cpuDeck.Add(deck[i]);
            }
        }
        Debug.Log("cards Been Dealed");
    }
}