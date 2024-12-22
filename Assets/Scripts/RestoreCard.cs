using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RestoreCard
{
    private Player player;
    public bool _isReturningCards;
    [SerializeField] private int restoreTime;


    //new script only for ressurect cards?
    public async void StartReturningCards()
    {
        _isReturningCards = true;

        while (player.Deck.DiscardPile.Count > 0) // Keep running until the discard pile is empty
        {
            await Task.Delay(restoreTime); // Wait 

            if (player.Deck.DiscardPile.Count > 0) // Check if the discard pile still has cards
            {
                ReturnRandomCardToDeck();
            }
        }

        _isReturningCards = false; // Reset the flag when the sequence ends
    }

    private void ReturnRandomCardToDeck()
    {
        int randomIndex = Random.Range(0, player.Deck.DiscardPile.Count); // Get a random card index
        Card card = player.Deck.DiscardPile[randomIndex]; // Get the card at the random index

        player.Deck.DiscardPile.RemoveAt(randomIndex); // Remove it from the discard pile
        player.Deck.cards.Add(card); // Add it back to the player's deck

        Debug.Log($"Card {card.name} returned to the player's deck.");
    }
}