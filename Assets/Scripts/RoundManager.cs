using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public Player player;
    public Opponent opponent; 
    public Card playerCard = null;
    public Card opponentCard = null;


    public RoundManager(Player _player, Opponent _opponent)
    {
        _player = player;
        _opponent = opponent;
    }

    public RoundManager()
    {
    }

    public void StartRound()
    {
        Debug.Log("StartRound");
        SetCardValue(playerCard);
        SetCardValue(opponentCard);
        CompareCards();
    }
    
    public void SetCardValue(Card card)
    {
        int value = Random.Range(1, 14);
        // card = gameObject.AddComponent<Card>();
        card.CardValue = value; 
        Debug.Log(card.CardValue);
    }

    private void CompareCards()
    {
        if (playerCard.CardValue > opponentCard.CardValue) // if player wins
        {
            player.Points++;
            Debug.Log("player points");
        }
        else if (playerCard.CardValue < opponentCard.CardValue) // if opponent wins
        {
            opponent.Points++;
            Debug.Log("opponent points");
        }
    }
}
