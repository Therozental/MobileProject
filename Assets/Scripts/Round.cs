using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using System.Threading.Tasks;
using Task = UnityEditor.VersionControl.Task;

public class Round : MonoBehaviour
{
    public Player Player;
    public CPU Cpu;
    public Deck deck;
    private Card _playerCard;
    private Card _cpuCard;
    private bool _isInTie = false;
    [SerializeField] private GameObject PlayerCard;
    [SerializeField] private GameObject CpuCard;

    public Round(Player _player, CPU _cpu)
    {
        _player = Player;
        _cpu = Cpu;
    }

    public  void StartRound()
    {
            Debug.Log("StartRound");
            PlayerDrawCard();
            CPUDrawCard();
            CompareCards();
        
    }

    private void PlayerDrawCard()
    {
         // Task.Delay(1000);
        _playerCard = deck.playerDeck[0];
        deck.playerDeck.RemoveAt(0);
        Debug.Log($"Player card {_playerCard}");
        _playerCard.transform.SetParent(PlayerCard.transform);
        _playerCard.transform.position = PlayerCard.transform.position;
    }

    private void CPUDrawCard()
    {
     //   await Task.Delay(3000);
        _cpuCard = deck.cpuDeck[0];
        deck.cpuDeck.RemoveAt(0);
        Debug.Log($"CPU card {_cpuCard}");
        _cpuCard.transform.SetParent(CpuCard.transform);
        _cpuCard.transform.position = CpuCard.transform.position;
        
    }

    private void CompareCards()
    {
        int differenceValue = 0;

        if (_playerCard.Value > _cpuCard.Value) // if player wins
        {
            differenceValue = _playerCard.Value - _cpuCard.Value; // get the differance between the values
            // add it to the player overall points
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
            if (_isInTie) // if its a tie round increase the points
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

    private async void CardTie()
    {
        Debug.Log("Card tied");
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