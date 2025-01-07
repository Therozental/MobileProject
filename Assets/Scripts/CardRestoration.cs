using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CardRestoration
{
    public Player _player;
    public bool _isReturningCards;

    public CardRestoration(Player player)
    {
        _player = player;
    }

    public async void StartReturningCards(int restoreTime)
    {
        _isReturningCards = true;

        while (_player.Deck.DiscardPile.Count > 0) // Keep running until the discard pile is empty
        {
            await Task.Delay(restoreTime); // Wait 

            if (_player.Deck.DiscardPile.Count > 0) // Check if the discard pile still has cards
            {
                ReturnRandomCardToDeck();
            }
        }

        _isReturningCards = false; // Reset the flag when the sequence ends
    }

    private void ReturnRandomCardToDeck()
    {
        int randomIndex = Random.Range(0, _player.Deck.DiscardPile.Count); // Get a random card index
        Card card = _player.Deck.DiscardPile[randomIndex]; // Get the card at the random index
        
        if (card != null)
        {
            _player.Deck.DiscardPile.RemoveAt(randomIndex); // Remove it from the discard pile
            _player.Deck.cards.Add(card); // Add it back to the player's deck

            Debug.Log($"Card {card.name} returned to the player's deck.");
        }
    }
}