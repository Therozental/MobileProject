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
    
    [Header("References")]
    public Player Player;
    public CPU Cpu;
    public Round Round;
    
    [Header("UI Elements")]
    public CoinCounter coinCounter;
    public ProgressBar progressBar;
    public GameObject shopPopup;

    [Header("Game Elements")]
    [SerializeField] private int CardRestoreTime;
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
        Round.StartRound();
        //event of endround
        Round.CompareCards();
        CleanCards(); // remove the round cards to discard pile/return the last on deck list
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
                    // ***add a ValueEvent and a gameObject that appears with the winner/loser and the differanceValue***
                    Player.Points += (differenceValue * 3); // if it's a tie round decrease the points
                    
                    coinCounter.UpdatePoints(Player.Points);
                    audioManager.PlaySfx(audioManager.warWin);
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
                Debug.Log("card tie (will be fixed later)");
               // CardTie();
                audioManager.PlaySfx(audioManager.playCard);
                break;
            }
        }
    }

    private void CheckPileCount()
    {
        // check the number of cards the player has, send a signal if player's out of cards
        if (Player.Deck.cards.Count <= 0)
        {
            // ***add an pop up event that say your deck is empty***
            audioManager.PlaySfx(audioManager.noMoreCards);
            shopPopup.SetActive(true); //openes the shop
            Debug.Log("player deck is empty");            
        }
    }

    private void CleanCards()
    {
        // add the card to the discard pile
        Player.Deck.DiscardPile.Add(Round._playerCard); 
        Debug.Log($"{Round._playerCard} has card discarded");
        
        // add it to the end of the cpu deck so it can be repeated
        Cpu.Deck.cards.Insert(Cpu.Deck.cards.Count,Round._cpuCard); 
        Debug.Log($"{Round._cpuCard} has card discarded");

        // Start the card return sequence if it's not already running
        if (!CardRestoration._isReturningCards)
        {
            CardRestoration.StartReturningCards(CardRestoreTime);
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