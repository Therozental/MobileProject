using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int Value;
    public string Suit;

    public Card(int value, string suit)
    {
        Value = value;
        Suit = suit;
    }
}