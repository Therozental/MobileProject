using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Round round;
    public Player player;
    public CPU cpu;
    public Deck deck;

    // Start is called before the first frame update
    void Start()
    {
        deck.CreateDeck();
        deck.DealCards();
        Gameloop();
    }

    public void Awake()
    {
        //Singletone:

        // if there is no instance, we initialize it
        if (Instance == null)
        {
            Initialize();
        }
        // if this instance is not the original, we destroy it
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        Instance = this;

        if (deck == null)
        {
            deck = new Deck();
        }

        if (round == null)
        {
            round = new Round(player, cpu); // Ensure round is properly created
        }

        // Assign cpu and player to round
        if (cpu != null && player != null)
        {
            round.Cpu = cpu;
            round.Player = player;
        }
        else
        {
            Debug.LogError("CPU or Player is null! Make sure they are assigned.");
        }
    }

    void Gameloop()
    {
        while ((deck.cpuDeck.Count != 0) || (deck.playerDeck.Count != 0)) // until there are cards in the
        {
            round.StartRound();
        }

        MatchResults();
    }

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
}