using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Stats")] public int Points = 0;
    public int Level = 0;
    public int Cash = 0;
    
    [Header("References")]
    public Deck Deck;
    [SerializeField] private Transform playerPile;
    
    private async Task DrawCard(Card playerCard)
    {
        await Task.Delay(100);
        playerCard = Deck.DrawTopCard(); // remove the top card from the pile
        // _playerCard.gameObject.SetActive(true);
        Debug.Log($"Player card {playerCard}");
    }
}