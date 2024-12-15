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
    
}