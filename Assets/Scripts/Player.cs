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
    [SerializeField] private PileCounter pileCounter;

    private async Task DrawCard(Card playerCard)
    {
        await Task.Delay(100);
        playerCard = Deck.DrawTopCard(); // remove the top card from the pile
        // _playerCard.gameObject.SetActive(true);
        Debug.Log($"Player card {playerCard}");


    }

    private void Update()
    {
       int number = Deck.cards.Count;
       pileCounter.NumberText.text = $"{number} Cards Left";
    }
}