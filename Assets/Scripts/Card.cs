using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public enum Suits
{
    Club,
    Heart,
    Diamond,
    Spade,
    Joker
}

[Serializable]
public class Card : MonoBehaviour
{
    public int Value;
    public Suits Suit;
    
    /*
    public Image CardArt;
    public bool isFirstJoker = false;

    [Header("Suits lists")] public List<Sprite> Club = new List<Sprite>();
    public List<Sprite> Spade = new List<Sprite>();
    public List<Sprite> Heart = new List<Sprite>();
    public List<Sprite> Diamond = new List<Sprite>();
    public List<Sprite> Joker = new List<Sprite>();

    public void SetCard(int value, Suits suit)
    {
        Value = value;
        Suit = suit;

        switch (Suit)
        {
            case Suits.Club:
            {
                CardArt.sprite = Club[TranslateValueToIndex(Value)];
                break;
            }
            case Suits.Heart:
            {
                CardArt.sprite = Heart[TranslateValueToIndex(Value)];
                break;
            }
            case Suits.Spade:
            {
                CardArt.sprite = Spade[TranslateValueToIndex(Value)];
                break;
            }
            case Suits.Diamond:
            {
                CardArt.sprite = Diamond[TranslateValueToIndex(Value)];
                break;
            }
            case Suits.Joker:
            {
                if (isFirstJoker)
                {
                    CardArt.sprite = Joker[0];
                }
                else
                {
                    CardArt.sprite = Joker[1];
                }

                break;
            }
            default: break;
        }
    }

    private int TranslateValueToIndex(int value)
    {
        if (value == 14)
        {
            return 0;
        }

        return value - 1;
    }
    
    */
}