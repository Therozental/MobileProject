using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Task = System.Threading.Tasks.Task;

public class Round : MonoBehaviour
{
    public Deck playerDeck;
    public Deck cpuDeck;
    public Player Player;
    private Card _playerCard;
    private Card _cpuCard;
    private bool _isInTie = false;
    private bool _isReturningCards;
    public CoinCounter coinCounter;
    [SerializeField] private GameObject PlayerCard;
    [SerializeField] private GameObject CpuCard;
    [SerializeField] private int restoreTime;


    public void InitRound()
    {
        playerDeck.Shuffle();
        cpuDeck.Shuffle();
    }

    public async void StartRound()
    {
        Debug.Log("StartRound");
        PlayerDrawCard();
        CPUDrawCard();
        CompareCards();
        CheckPileCount();
    }


    private async Task PlayerDrawCard()
    {
        await Task.Delay(100);
        _playerCard = playerDeck.DrawTopCard(); // remove the top card from the pile
        Debug.Log($"Player card {_playerCard}");

        _playerCard.transform.SetParent(PlayerCard.transform);
        _playerCard.transform.position = PlayerCard.transform.position;
    }

    private async Task CPUDrawCard()
    {
        await Task.Delay(500);
        _cpuCard = cpuDeck.DrawTopCard(); // remove the top card from the pile
        Debug.Log($"CPU card {_cpuCard}");

        _cpuCard.transform.SetParent(CpuCard.transform);
        _cpuCard.transform.position = CpuCard.transform.position;
    }

    private async Task CompareCards()
    {
        int differenceValue = 0;

        if (_playerCard.Value > _cpuCard.Value) // if player wins
        {
            differenceValue =
                _playerCard.Value -
                _cpuCard.Value; // get the differance between the values, add it to the player overall points

            if (_isInTie) // if it's a tie round
            {
                Player.Points += (differenceValue * 3); // if it's a tie round decrease the points
                coinCounter.AddPoints(Player.Points);
                
            }
            else // if not in tie round
            {
                Player.Points += differenceValue;
                coinCounter.AddPoints(Player.Points);
            }
            
            Player.GetExp();

            Debug.Log($"PLAYER WON! player points increased by {differenceValue}, its value is {Player.Points}");
        }
        else if (_playerCard.Value < _cpuCard.Value) // if cpu wins
        {
            if (_isInTie) // if it's a tie round increase the points
            {
                Player.Points -= (differenceValue * 3);
                
            }
            else // if not in tie round
            {
                Player.Points -= differenceValue;
            }

            Debug.Log($"CPU WON! player points decreased by {differenceValue}, its value is {Player.Points}");
        }
        else if (_playerCard.Value == _cpuCard.Value)
        {
            Debug.Log("card tie (will be fixed later)");
            //   CardTie();
        }

        CleanCards(); // remove the round cards to discard pile/return the last on deck list
        _isInTie = false;
    }

    private void CardTie()
    {
        Debug.Log("Card tied");
        _isInTie = true;
        Remove3Cards();
        StartRound();
    }

    private void Remove3Cards() // if both cards has the same value, take out 3 cards from each deck and try again
    {
        for (int i = 0; i < 3; i++)
        {
            Card removedPlayerCard = playerDeck.DrawTopCard(); //remove the first card from the player pile
            playerDeck.DiscardPile.Add(removedPlayerCard); // add the card to the player discard pile
            Debug.Log("Player removed 3 cards");

            Card removedCpuCard = cpuDeck.DrawTopCard(); // remove the first card from the cpu pile
            cpuDeck.deck.Insert(cpuDeck.deck.Count, removedCpuCard); // put the card last in the cpu deck
            Debug.Log("CPU removed 3 cards");
        }
        //have some cool animation each card removal
    }

    private void CheckPileCount()
    {
        // check the number of cards the player has, send a signal if player's out of cards
        if (playerDeck.deck.Count <= 0)
        {
            Debug.Log("player deck is empty");
            // do a pop up that your deck is empty
        }
    }

    private void CleanCards()
    {
        playerDeck.DiscardPile.Add(_playerCard); // add the card to the discard pile
        cpuDeck.deck.Insert(cpuDeck.deck.Count, _cpuCard); // add it to the end of the cpu deck so it can be repeated

        // Start the card return sequence if it's not already running
        if (!_isReturningCards)
        {
            StartReturningCards();
        }
    }


    private async void StartReturningCards()
    {
        _isReturningCards = true;

        while (playerDeck.DiscardPile.Count > 0) // Keep running until the discard pile is empty
        {
            await Task.Delay(restoreTime); // Wait 

            if (playerDeck.DiscardPile.Count > 0) // Check if the discard pile still has cards
            {
                ReturnRandomCardToDeck();
            }
        }

        _isReturningCards = false; // Reset the flag when the sequence ends
    }

    private void ReturnRandomCardToDeck()
    {
        int randomIndex = Random.Range(0, playerDeck.DiscardPile.Count); // Get a random card index
        Card card = playerDeck.DiscardPile[randomIndex]; // Get the card at the random index

        playerDeck.DiscardPile.RemoveAt(randomIndex); // Remove it from the discard pile
        playerDeck.deck.Add(card); // Add it back to the player's deck

        Debug.Log($"Card {card.name} returned to the player's deck.");
    }
}