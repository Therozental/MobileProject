using System.Collections;
using System.Threading.Tasks;
using UnityEngine;


public class Round : MonoBehaviour
{
    public Card playerCard;
    public Card cpuCard;

    [Header("References")] [SerializeField]
    private Player player;

    [SerializeField] private CPU cpu;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator cpuAnimator;
    [SerializeField] private AudioManager audioManager;

    [Header("Placements")] [SerializeField]
    private GameObject PlayerCardPlacement;

    [SerializeField] private GameObject CpuCardPlacement;

    public void InitRound()
    {
        player.Deck.Shuffle();
        cpu.Deck.Shuffle();
        Debug.Log("Cards Shuffled");
    }

    public async void StartRound()
    {
        Debug.Log("Start Round");
        PlayerTurn();
        CpuTurn();
        await Task.Delay(300);
        audioManager.PlaySfx(audioManager.computerPlayCard);
    }

    public void StartTieRound()
    {
        GameManager.instance.CheckPileCount();
        Debug.Log("Start Tie Round");
        player.Deck.PlayerRemove3Cards();
        playerAnimator.SetTrigger("Tie");
        cpu.Deck.CPURemove3Cards();
        cpuAnimator.SetTrigger("Tie");
        PlayerTurn();
        CpuTurn();
        audioManager.PlaySfx(audioManager.warFlip);
    }


    public void PlaceCard(Card currentCard, GameObject cardPilePlacement)
    {
        currentCard.transform.SetParent(cardPilePlacement.transform);
        currentCard.transform.position = cardPilePlacement.transform.position;
    }

    public void PlayerTurn()
    {
        //player draws top card and place it in the middle of the screen
        playerCard = player.Deck.DrawTopCard();
        PlaceCard(playerCard, PlayerCardPlacement);
        
    }

    public void CpuTurn()
    {
        //cpu draws top card and place it in the middle of the screen
        cpuCard = cpu.Deck.DrawTopCard();
        PlaceCard(cpuCard, CpuCardPlacement);
    }

    public void CompareCards()
    {
        int differenceValue = 0;
        differenceValue = playerCard.Value - cpuCard.Value;

        if (playerCard.Value > cpuCard.Value) // if player wins
        {
            GameManager.instance.RoundResult(Result.Win, differenceValue);
        }
        else if (playerCard.Value < cpuCard.Value) // if cpu wins
        {
            GameManager.instance.RoundResult(Result.Lose, differenceValue);
        }
        else if (playerCard.Value == cpuCard.Value)
        {
            GameManager.instance.RoundResult(Result.Tie, differenceValue);
        }
    }
}