using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Round round;
    public Player Player;
    public CPU Cpu;
    public Deck deck;
    

    // Start is called before the first frame update
    void Start()
    {
        deck.Shuffle();
        deck.DealCards();
       // Gameloop();
    }

    public void Awake()
    {
        //Singletone:
        // if there is no instance, we initialize it
        if (instance == null)
        {
            Initialize();
        }
        // if this instance is not the original, we destroy it
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        instance = this;
    }

    void Gameloop()
    {
        // //while ((deck.cpuDeck.Count != 0) || (deck.playerDeck.Count != 0)) // until there are cards in the
        // {
        //  //   round.StartRound();
        // }

        GameOver();
    }

    void GameOver()
    {
        
    }

/*
    void MatchResults()
    {
        if (player.Points > cpu.Points)
        {
            Debug.Log("player win!");
        }
        else if (player.Points < cpu.Points)
        {
            Debug.Log("player lost!");
        }
        else
        {
            Debug.Log("its a tie!");
        }
    }
    */
}