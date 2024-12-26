using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Task = System.Threading.Tasks.Task;


public class Round : MonoBehaviour
{
    public Card _playerCard;
    public Card _cpuCard;

    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private CPU cpu;

    [Header("Placements")]
    [SerializeField] private GameObject PlayerCardPlacement;
    [SerializeField] private GameObject CpuCardPlacement;


    public void InitRound()
    {
        player.Deck.Shuffle();
        cpu.Deck.Shuffle();
    }

    public void StartRound()
    {
        Debug.Log("StartRound");
        PlayerTurn();
        CpuTurn();
        //set event endround
    }

    public void PlaceCard(Card currentCard, GameObject cardPilePlacement)
    {
        currentCard.transform.SetParent(cardPilePlacement.transform); 
        currentCard.transform.position = cardPilePlacement.transform.position;
    }

    private void PlayerTurn()
    {
        //player draws top card and place it in the middle of the screen
        _playerCard = player.Deck.DrawTopCard();
        PlaceCard(_playerCard, PlayerCardPlacement);
    }

    private void CpuTurn()
    {
        //cpu draws top card and place it in the middle of the screen
        _cpuCard = cpu.Deck.DrawTopCard();
        PlaceCard(_cpuCard, CpuCardPlacement);
    }

    public void CompareCards()
    {
        int differenceValue = 0;
        differenceValue = _playerCard.Value - _cpuCard.Value;
        
        if (_playerCard.Value > _cpuCard.Value) // if player wins
        {
            GameManager.instance.RoundResult(Result.Win, differenceValue);
        }
        else if (_playerCard.Value < _cpuCard.Value) // if cpu wins
        {
            GameManager.instance.RoundResult(Result.Lose, differenceValue);
        }
        else if (_playerCard.Value == _cpuCard.Value)
        {
            GameManager.instance.RoundResult(Result.Tie, differenceValue);
        }
    }
}