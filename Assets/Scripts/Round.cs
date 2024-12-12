using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public Deck deck;
    public Player Player;
    public CPU Cpu;
    private Card _playerCard;
    private Card _cpuCard;
    private bool _isInTie = false;
    [SerializeField] private GameObject PlayerCard;
    [SerializeField] private GameObject CpuCard;


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
        _playerCard = Player.PlayerDeck.deck[0];
        Player.PlayerDeck.deck.RemoveAt(0); // remove card from the player pile
        Debug.Log($"Player card {_playerCard}");

        _playerCard.transform.SetParent(PlayerCard.transform);
        _playerCard.transform.position = PlayerCard.transform.position;
    }

    private void CPUDrawCard()
    {
        _cpuCard = Cpu.cpuDeck.deck[0];
        Cpu.cpuDeck.deck.RemoveAt(0); // remove card from the player pile
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
        if (Player.PlayerDeck.deck.Count <= 0)
        {
            Debug.Log("player deck is empty");
        }
    }

    public void CleanCards()
    {
        deck.DiscardPile.Add(_playerCard); // add the card to the discard pile

        Cpu.cpuDeck.deck.Insert(54, _cpuCard); // add it to the end of the cpu deck so it can be repeated
    }

    private void Remove3Cards() // if both cards has the same value, take out 3 cards from each deck and try again
    {
        Player.PlayerDeck.deck.RemoveRange(0, 3);
        Cpu.cpuDeck.deck.RemoveRange(0, 3);
    }
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