using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public List<CardPackScriptableobject> availablePacks; // List of card packs available in the store
    public int playerPoints; // Player's available points
    public int playerCash; // Player's available cash
    public Deck playerDeck; // Reference to the player's deck
    public Player player;
    
}
