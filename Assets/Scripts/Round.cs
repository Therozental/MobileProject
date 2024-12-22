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
    [SerializeField] private Player player;
    [SerializeField] private CPU cpu;
    private Card _playerCard;
    private Card _cpuCard;
    [SerializeField] private GameObject PlayerCard;
    [SerializeField] private GameObject CpuCard;

    public void InitRound()
    {
        player.Deck.Shuffle();
        cpu.Deck.Shuffle();
    }

    public async void StartRound()
    {
        Debug.Log("StartRound");
        PlayerTurn();
        CpuTurn();
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

    public void PlayerTurn()
    {
        player.Deck.PlayCard(_playerCard);
        PlaceCard(_playerCard, PlayerCard);
    }

    public void CpuTurn()
    {
        cpu.Deck.PlayCard(_cpuCard);
        PlaceCard(_cpuCard, CpuCard);
    }

    public void PlaceCard(Card card, GameObject pile)
    {
        card.transform.SetParent(pile.transform);
        card.transform.position = pile.transform.position;
    }
}