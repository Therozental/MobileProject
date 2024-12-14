using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Deck2 : MonoBehaviour
{
    /*
    public struct CardInfo
    {
        public int value;
        public Suits suit;

        public CardInfo(int Value, object Suit)
        {
            value = Value;
            suit = (Suits)Suit;
        }
    }


    public List<CardInfo> DiscardPile = new List<CardInfo>();
    public List<CardInfo> deck = new List<CardInfo>();

    public Card currentCard;
    private int[] cardValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

    private void Start()
    {
        //restart the deck
        foreach (int value in cardValues)
        {
            foreach (var Suit in Enum.GetValues(typeof(Suits)))
            {
                deck.Add(new CardInfo(value, Suit));
            }
        }

        deck.Add(new CardInfo(15, Suits.Joker));
        deck.Add(new CardInfo(15, Suits.Joker));
    }
    
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
        CardInfo topCard = deck[0];
        currentCard.SetCard(topCard.value, topCard.suit);
        deck.RemoveAt(0); // remove card from the player pile
        return topCard;
    }
    */
}