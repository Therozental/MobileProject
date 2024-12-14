using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Round Round;

    // Start is called before the first frame update
    void Start()
    {
        Round.InitRound();
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