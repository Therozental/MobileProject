using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Round : MonoBehaviour
{
    public Player Player;
    public CPU Cpu;
    public Deck deck;
    private Card _playerCard;
    private Card _cpuCard;

    bool _isInTie = false;

    public Round(Player _player, CPU _cpu)
    {
        _player = Player;
        _cpu = Cpu;
    }

    public void StartRound()
    {
        PlayerDrawCard();
        CPUDrawCard();
        CompareCards();
    }

    private void PlayerDrawCard()
    {
        _playerCard = deck.playerDeck[0];
        deck.playerDeck.RemoveAt(0);
    }

    private void CPUDrawCard()
    {
        _cpuCard = deck.cpuDeck[0];
        deck.cpuDeck.RemoveAt(0);
    }

    private void CompareCards()
    {
        int differenceValue = 0;

        if (_playerCard.Value > _cpuCard.Value) // if player wins
        {
            differenceValue = _playerCard.Value - _cpuCard.Value; // get the differance between the values
            // add it to the player overall points
            if (_isInTie) // if its a tie round
            {
                Player.Points += (differenceValue * 3); // if its a tie round decrease the points
            }
            else // if not in tie round
            {
                Player.Points += differenceValue;
            }

            Player.GetExp();

            Debug.Log($"player points increased by {differenceValue}, its value is {Player.Points}");
        }
        else if (_playerCard.Value < _cpuCard.Value) // if cpu wins
        {
            if (_isInTie) // if its a tie round increase the points
            {
                Player.Points -= (differenceValue * 3);
            }
            else // if not in tie round
            {
                Player.Points -= differenceValue;
            }

            Debug.Log($"player points decreased by {differenceValue}, its value is {Player.Points}");
        }
        else if (_playerCard.Value == _cpuCard.Value)
        {
            CardTie();
        }

        _isInTie = false;
    }

    private void CardTie()
    {
        _isInTie = true;
        Remove3Cards();
        StartRound();
    }

    private void Remove3Cards() // if both cards has the same value, take out 3 cards from each deck and try again
    {
        deck.playerDeck.RemoveRange(0, 3);
        deck.cpuDeck.RemoveRange(0, 3);
    }

    // for (int i = 0; i < 3; i++) //remove the 3 first cards in the deck
    // {
    //     deck.playerDeck.RemoveAt(0);
    //     
    //     Debug.Log($"Player card {deck.playerDeck[i]} was drawn");
    //
    //     deck.cpuDeck.RemoveAt(0);
    //     Debug.Log($"cpu card {deck.cpuDeck[i]} was drawn");
    // }


    // private void TieRound()
    // {
    //     PlayerDrawCard();
    //     CPUDrawCard();
    //     if (playerCard.Value > cpuCard.Value) // if player wins
    //     {
    //         int differenceValue = playerCard.Value - cpuCard.Value; // get the differance between the values
    //         player.Points += (differenceValue * 3); // add it to the player overall points
    //
    //         Debug.Log($"player points increased by {player.Points}, its value is {differenceValue}");
    //     }
    //     else if (playerCard.Value < cpuCard.Value) // if cpu wins
    //     {
    //         int differenceValue = cpuCard.Value - playerCard.Value;
    //         player.Points -= (differenceValue * 3);
    //         Debug.Log("opponent points");
    //     }
    //     else if (playerCard.Value == cpuCard.Value)
    //     {
    //         CardTie();
    //     }
    // }
}