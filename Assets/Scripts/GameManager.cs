using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Result
{
    Win,
    Lose,
    Tie
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Player;
    public Round Round;
    public CoinCounter coinCounter;
    public RestoreCard RestoreCard;
    public CPU Cpu;
    public ProgressBar progressBar;

    public bool _isInTie = false;


    void Start()
    {
        Round.InitRound(); //initialize the round
        Debug.Log("round initialized");
    }

    public void Awake()
    {
        //Singletone:
        if (instance == null) // if there is no instance, we initialize it
        {
            Initialize();
        }
        else if (instance != this) // if this instance is not the original, we destroy it
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        instance = this;
    }

    public void RoundPlay()
    {
        Round.StartRound();
        Round.CompareCards();
        //  CleanCards(); // remove the round cards to discard pile/return the last on deck list
        ResetTieParameter();
        CheckPileCount();
    }

    public void RoundResult(Result result, int differenceValue)
    {
        switch (result)
        {
            case (Result.Win):
            {
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

                Debug.Log($"PLAYER WON! player points increased by {differenceValue}, its value is {Player.Points}");
                progressBar.GetExp(differenceValue);
                break;
            }
            case (Result.Lose):
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
                break;
            }
            case (Result.Tie):
            {
                Debug.Log("card tie (will be fixed later)");
                //  CardTie();
                break;
            }
        }
    }

    private void CheckPileCount()
    {
        // check the number of cards the player has, send a signal if player's out of cards
        if (Player.Deck.cards.Count <= 0)
        {
            Debug.Log("player deck is empty");
            // do a pop up that your deck is empty
        }
    }

    private void CleanCards(Card _playerCard, Card _cpuCard)
    {
        Player.Deck.DiscardPile.Add(_playerCard); // add the card to the discard pile
        //  _playerCard.gameObject.SetActive(false);
        Cpu.Deck.cards.Insert(Cpu.Deck.cards.Count,
            _cpuCard); // add it to the end of the cpu deck so it can be repeated
        //  _cpuCard.gameObject.SetActive(false);

        // Start the card return sequence if it's not already running
        if (!RestoreCard._isReturningCards)
        {
            RestoreCard.StartReturningCards();
        }
    }

    private void CardTie()
    {
        Debug.Log("Card tied");
        _isInTie = true;
        Player.Deck.PlayerRemove3Cards();
        Cpu.Deck.CPURemove3Cards();
        Round.StartRound();
    }

    private bool ResetTieParameter()
    {
        return _isInTie = false;
    }
}