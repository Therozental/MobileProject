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
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator cpuAnimator;

    [Header("Placements")]
    [SerializeField] private GameObject PlayerCardPlacement;
    [SerializeField] private GameObject CpuCardPlacement;

    public void InitRound()
    {
        player.Deck.Shuffle();
        cpu.Deck.Shuffle();
        Debug.Log("Cards Shuffled");
    }

    public void StartRound()
    {
        Debug.Log("Start Round");
        PlayerTurn();
        CpuTurn();
        
        //set event endround
    }
    
    public void StartTieRound()
    {
        Debug.Log("Start Tie Round");
        player.Deck.PlayerRemove3Cards();
        playerAnimator.SetTrigger("Tie");
        cpu.Deck.CPURemove3Cards();
        cpuAnimator.SetTrigger("Tie");
        PlayerTurn();
        CpuTurn();
        //set event endround
    }
    

    public void PlaceCard(Card currentCard, GameObject cardPilePlacement)
    {
        currentCard.transform.SetParent(cardPilePlacement.transform);
        currentCard.transform.position = cardPilePlacement.transform.position;
    }

    public void PlayerTurn()
    {
        //player draws top card and place it in the middle of the screen
        _playerCard = player.Deck.DrawTopCard();
        PlaceCard(_playerCard, PlayerCardPlacement);
    }

    public void CpuTurn()
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