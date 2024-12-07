using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Round : MonoBehaviour
{
    public Player player;
    public CPU cpu;
    private Card playerCard;
    private Card cpuCard;
    public Deck deck;

    public Round(Player _player, CPU _cpu)
    {
        _player = player;
        _cpu = cpu;
    }

    public void StartRound()
    {
        PlayerDrawCard();
        CPUDrawCard();
        CompareCards();
    }

    private void PlayerDrawCard()
    {
        playerCard = deck.playerDeck[0];
        deck.playerDeck.RemoveAt(0);
    }

    private void CPUDrawCard()
    {
        cpuCard = deck.cpuDeck[0];
        deck.cpuDeck.RemoveAt(0);
    }

    private void CompareCards()
    {
        if (playerCard.Value > cpuCard.Value) // if player wins
        {
            player.Points++;
            Debug.Log("player points");
        }
        else if (playerCard.Value < cpuCard.Value) // if cpu wins
        {
            cpu.Points++;
            Debug.Log("opponent points");
        }
        else if (playerCard.Value == cpuCard.Value)
        {
            CardTie();
        }
    }

    private void CardTie() // if both cards has the same value, take out 3 cards from each deck and try again
    {
        for (int i = 0; i < 3; i++) //remove the 3 first cards in the deck
        {
            deck.playerDeck.RemoveAt(0);
            Debug.Log($"Player card {deck.playerDeck[i]} was drawn");
            
            deck.cpuDeck.RemoveAt(0);
            Debug.Log($"cpu card {deck.cpuDeck[i]} was drawn");
        }
        StartRound();
    }

    /*

    public void SetCardValue(Card card)
    {
        int value = Random.Range(1, 14);
        // card = gameObject.AddComponent<Card>();
        card.CardValue = value;
        Debug.Log(card.CardValue);
    }


    */
}