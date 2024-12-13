using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public Deck playerDeck;
    public Deck cpuDeck;
    public Player Player;
    // public CPU Cpu;
    private Card _playerCard;
    private Card _cpuCard;
    private bool _isInTie = false;
    [SerializeField] private GameObject PlayerCard;
    [SerializeField] private GameObject CpuCard;
    [SerializeField] private Cooldown CardCooldown;
    [SerializeField] private float CooldownTimer;
    public Timer Timer;

    public void InitRound()
    {
        playerDeck.Shuffle();
        cpuDeck.Shuffle();
    }

    public void StartRound()
    {
        Debug.Log("StartRound");
        PlayerDrawCard();
        CPUDrawCard();
        CompareCards();
        CheckPileCount();
    }


    private void PlayerDrawCard()
    {
        _playerCard = playerDeck.DrawTopCard(); // remove the top card from the pile
        Debug.Log($"Player card {_playerCard}");

        _playerCard.transform.SetParent(PlayerCard.transform);
        _playerCard.transform.position = PlayerCard.transform.position;
    }

    private void CPUDrawCard()
    {
        _cpuCard = cpuDeck.DrawTopCard(); // remove the top card from the pile
        Debug.Log($"CPU card {_cpuCard}");

        _cpuCard.transform.SetParent(CpuCard.transform);
        _cpuCard.transform.position = CpuCard.transform.position;
    }

    private void CompareCards()
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
            }
            else // if not in tie round
            {
                Player.Points += differenceValue;
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
            CardTie();
        }

        CleanCards();
        _isInTie = false;
    }

    private void CardTie()
    {
        Debug.Log("Card tied");
        _isInTie = true;
        Remove3Cards();
        StartRound();
    }

    public void CheckPileCount() // check the number of cards the player has, send a signal if player's out of cards
    {
        if (playerDeck.deck.Count <= 0)
        {
            Debug.Log("player deck is empty");
            // do a pop up that your deck is empty
            //start Cardcooldown?

            // if deck is full stop cooldown
            // if deck is not full - start cooldown
        }
        //retun
    }

    public void RestoreToPile()
    {
        //  playerDeck.DiscardPile.RemoveAt(0);
    }

    public void CleanCards()
    {
        playerDeck.DiscardPile.Add(_playerCard); // add the card to the discard pile
        cpuDeck.deck.Insert(cpuDeck.deck.Count, _cpuCard); // add it to the end of the cpu deck so it can be repeated
    }

    private void Remove3Cards() // if both cards has the same value, take out 3 cards from each deck and try again
    {
        // playerDeck.deck.RemoveRange(0, 3);
        for (int i = 0; i < 3; i++)
        {
            Card removedPlayerCard = playerDeck.DrawTopCard(); //remove the first card from the player pile
            playerDeck.DiscardPile.Add(removedPlayerCard); // add the card to the player discard pile

            Card removedCpuCard = cpuDeck.DrawTopCard(); // remove the first card from the cpu pile
            cpuDeck.deck.Insert(cpuDeck.deck.Count, removedCpuCard); // put the card last in the cpu deck
        }
    }
    // every x time, return a card rom the discard pile into the player deck.
    // put the card in a random index.
    // if 
}


/*




   private void TieRound()
   {
       PlayerDrawCard();
       CPUDrawCard();
       if (playerCard.Value > cpuCard.Value) // if player wins
       {
           int differenceValue = playerCard.Value - cpuCard.Value; // get the differance between the values
           player.Points += (differenceValue * 3); // add it to the player overall points

           Debug.Log($"player points increased by {player.Points}, its value is {differenceValue}");
       }
       else if (playerCard.Value < cpuCard.Value) // if cpu wins
       {
           int differenceValue = cpuCard.Value - playerCard.Value;
           player.Points -= (differenceValue * 3);
           Debug.Log("opponent points");
       }
       else if (playerCard.Value == cpuCard.Value)
       {
           CardTie();
       }
   }
   */