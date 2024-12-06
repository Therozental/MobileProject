using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RoundManager roundManager; 
    public Player player; 
    public Opponent opponent;
    
    // Start is called before the first frame update
    void Start()
    {
        Gameloop();
    }
    
    public void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        roundManager.opponent = opponent;
        roundManager.player = player;
    }
    
    
    void MatchResults()
    {
        if (player.Points > opponent.Points)
        {
            Debug.Log("player win!");
        }
        else if (player.Points < opponent.Points)
        {
            Debug.Log("player lost!");
        }
        else
        {
            Debug.Log("its a tie!");
        }
    }

    void Gameloop()
    {
        for (int i = 0; i < 20; i++)
        {
          //  roundManager.StartRound();
        }
        MatchResults();
    }
}




/*
 * to do:
 * create the core mechanic
 * create randomizers
 * make a list of 13 ints to randomize from them
 * check the values
 *create 2 deck of cards - playerDeck and OpponentDeck
 * after 20 rounds check winner
 */
