using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Player;
    public CPU Cpu;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerDeck.Shuffle();
        Cpu.cpuDeck.Shuffle();
        // deck.Shuffle();
        // deck.DealCards();
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

}