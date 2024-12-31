using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
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

    [Header("References")] public Player Player;
    public CPU Cpu;
    public Round Round;

    [Header("UI Elements")]
    public CoinCounter coinCounter;
    public ProgressBar progressBar;
    public GameObject shopPopup;
    
    [Header("Game Elements")]
    [SerializeField, Tooltip("time for card to restore to deck")] private int CardRestoreTime;

    public AudioManager audioManager;
    public CardRestoration CardRestoration;
    public bool _isInTie = false;


    void Start()
    {
        Round.InitRound(); //initialize the round
        Debug.Log("round initialized");
        CardRestoration = new CardRestoration(Player);
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

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Initialize()
    {
        instance = this;
    }

    public void RoundPlay()
    {
        if (_isInTie)
        {
            Round.StartTieRound();
        }
        else
        {
            Round.StartRound();
        }
        Round.CompareCards();
        CleanCards(); // remove the round cards to discard pile/return the last on deck list
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
                    // ***add a ValueEvent and a gameObject that appears with the winner/loser and the differanceValue***
                    Player.Points += (differenceValue * 3); // if it's a tie round decrease the points
                    Debug.Log($"PLAYER WON TIE! player points increased by {differenceValue * 3}, its value is {Player.Points}");
                    coinCounter.UpdatePoints(Player.Points);
                    audioManager.PlaySfx(audioManager.warWin);
                    ResetTieParameter();
                }
                else // if not in tie round
                {
                    // ***add a ValueEvent and a gameObject that appears with the winner/loser and the differanceValue***
                    Player.Points += differenceValue;
                    coinCounter.UpdatePoints(Player.Points);
                    audioManager.PlaySfx(audioManager.winPoints);
                }

                Debug.Log($"PLAYER WON! player points increased by {differenceValue}, its value is {Player.Points}");
                progressBar.GetExp(differenceValue);
                break;
            }
            case (Result.Lose):
            {
                if (_isInTie) // if it's a tie round increase the points
                {
                    // ***add a ValueEvent and a gameObject that appears with the winner/loser and the differanceValue***
                    Player.Points -= (differenceValue * 3);
                    audioManager.PlaySfx(audioManager.warLose);
                    coinCounter.UpdatePoints(Player.Points);
                    Debug.Log($"CPU WON TIE! player points decreased by {differenceValue * 3}, its value is {Player.Points}");
                    ResetTieParameter();
                }
                else // if not in tie round
                {
                    // ***add a ValueEvent and a gameObject that appears with the winner/loser and the differanceValue***
                    Player.Points -= differenceValue;
                }

                Debug.Log($"CPU WON! player points decreased by {differenceValue}, its value is {Player.Points}");
                break;
            }
            case (Result.Tie):
            {
                Debug.Log("card tie");
                CardTieSequence();
                audioManager.PlaySfx(audioManager.playCard);
                break;
            }
        }
    }

    public void CardTieSequence()
    {
      
        _isInTie = true;
        Debug.Log($"{_isInTie} true");
        //Round.StartRound();
    }
    
    public void CheckPileCount()
    {
        // check the number of cards the player has, send a signal if player's out of cards
        if (Player.Deck.cards.Count <= 0)
        {
            // ***add an pop up event that say your deck is empty***
            audioManager.PlaySfx(audioManager.noMoreCards);
            shopPopup.SetActive(true); //openes the shop
            Debug.Log("deck is empty");
        }
    }

    private void CleanCards()
    {
        // add the card to the discard pile
        Player.Deck.DiscardPile.Add(Round._playerCard);
        Debug.Log($"{Round._playerCard} discarded");

        // add it to the end of the cpu deck so it can be repeated
        Cpu.Deck.cards.Insert(Cpu.Deck.cards.Count, Round._cpuCard);
        Debug.Log($"{Round._cpuCard} discarded");

        // Start the card return sequence if it's not already running
        if (!CardRestoration._isReturningCards)
        {
            CardRestoration.StartReturningCards(CardRestoreTime);
        }
    }
    
    private bool ResetTieParameter()
    {
        Debug.Log($"{_isInTie} false");
        return _isInTie = false;
    }
}