using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPack : MonoBehaviour
{
    [SerializeField] private CardPackScriptableobject ScriptableObject;
    public Store store;

    public void PurchaseCardPoints()
    {
        if (store.player.Points >= ScriptableObject.costInPoints) // if player has enough points
        {
            // remove the points from the player
            store.player.Points -= ScriptableObject.costInPoints; 
            Debug.Log($"your sum points:{store.player.Points}");
        
            // add the pack cards to the deck
            for (int i = 0; i < ScriptableObject.packCards.Count; i++)
            {
                store.playerDeck.cards.Add(ScriptableObject.packCards[i]);
                Debug.Log($"{ScriptableObject.packCards[i]} added to you deck");
            }
        }
        Debug.Log("not enough point!");
        return;
    }
    /*
    public void PurchasePointsByCash()
    {
        if (store.player.Cash >= ScriptableObject.costInCash) // if player has enough points
        {
            // remove the cash from the player
            store.player.Cash -= ScriptableObject.costInCash; 
        
            // add the pack cards to the deck
            for (int i = 0; i < ScriptableObject.packCards.Count; i++)
            {
                store.playerDeck.deck.Add(ScriptableObject.packCards[i]);
            }
        }
    
    }
    */
}
