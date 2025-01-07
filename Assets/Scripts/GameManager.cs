using System.Threading.Tasks;
using UnityEngine;


public enum Result
{
    Win,
    Lose,
    Tie
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("References")] public Player Player;
    public CPU Cpu;
    public Round Round;

    [Header("UI Elements")] public CoinCounter coinCounter;
    public ProgressBar progressBar;
    public PopupManager popupManager;
    public GameObject tiePopup;
    public ParticleSystem winParticles;
    public GameObject notEnoughCards;

    [Header("Game Elements")] [SerializeField, Tooltip("time for card to restore to deck")]
    private int CardRestoreTime;


    [SerializeField, Tooltip("time delay for the sfx")]
    private int delayTime = 300;

    public AudioManager audioManager;
    public CardRestoration CardRestoration;
    public bool _isInTie = false;


    void Start()
    {
        Round.InitRound(); //initialize the round
        Debug.Log("round initialized");
        CardRestoration = new CardRestoration(Player);
    }

    public void Awake()
    {
        //Singletone:
        if (instance == null) // if there is no instance, we initialize it
        {
            Initialize();
        }
        else if (instance != this) // if this instance is not the original, we destroy it
        {
            Destroy(gameObject);
        }

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Initialize()
    {
        instance = this;
    }

    public void RoundPlay()
    {
       
        CheckPileCount();

        if (_isInTie)
        {
            Round.StartTieRound();
        }
        else
        {
            Round.StartRound();
        }

        Round.CompareCards();
        CleanCards(); // remove the round cards to discard pile/return the last on deck list
    }

    public async void RoundResult(Result result, int differenceValue)
    {
        switch (result)
        {
            case (Result.Win):
            {
                if (_isInTie) // if it's a tie round
                {
                    Player.Points += (differenceValue * 3); // if it's a tie round decrease the points
                    Debug.Log(
                        $"PLAYER WON TIE! player points increased by {differenceValue * 3}, its value is {Player.Points}");

                    // flip the cards 

                    await Task.Delay(1000);
                    audioManager.PlaySfx(audioManager.warWin);
                    // await Task.Delay(delayTime);
                    coinCounter.UpdatePoints(Player.Points);
                    ResetTieParameter();
                    break;
                }
                if (_isInTie == false) // if not in tie round
                {
                    Player.Points += differenceValue;

                    await Task.Delay(delayTime);
                    coinCounter.UpdatePoints(Player.Points);
                    audioManager.PlaySfx(audioManager.winPoints);
                }

                Debug.Log($"PLAYER WON! player points increased by {differenceValue}, its value is {Player.Points}");
                progressBar.GetExp(differenceValue);
                await Task.Delay(300);
                winParticles.Play();
                break;
            }
            case (Result.Lose):
            {
                if (_isInTie) // if it's a tie round increase the points
                {
                    Player.Points -= (differenceValue * 3);
                    
                    await Task.Delay(1000);
                    audioManager.PlaySfx(audioManager.warLose);
                    
                    //await Task.Delay(delayTime);
                 //   coinCounter.UpdatePoints(Player.Points);
                    Debug.Log(
                        $"CPU WON TIE! player points decreased by {differenceValue * 3}, its value is {Player.Points}");
                    ResetTieParameter();
                    break;
                }
                if (_isInTie == false) // if not in tie round
                {
                    Player.Points -= differenceValue;
                }

                Debug.Log($"CPU WON! player points decreased by {differenceValue}, its value is {Player.Points}");
                break;
            }
            case (Result.Tie):
            {
                await Task.Delay(delayTime);
                audioManager.PlaySfx(audioManager.tie);
                Debug.Log("card tie");
                CardTieSequence();
                break;
            }
        }
    }

    public void CardTieSequence()
    {
        _isInTie = true;
        tiePopup.SetActive(true);
        Debug.Log($"{_isInTie} true");
    }

    public void CheckPileCount()
    {
        // check the number of cards the player has, send a signal if player's out of cards
        if (Player.Deck.cards.Count <= 0)
        {
            notEnoughCards.SetActive(true);
            Debug.Log("deck is empty");
        }
    }

    private void CleanCards()
    {
        // add the card to the discard pile
        Player.Deck.DiscardPile.Add(Round.playerCard);
        Debug.Log($"{Round.playerCard} discarded");

        // add it to the end of the cpu deck so it can be repeated
        Cpu.Deck.cards.Insert(Cpu.Deck.cards.Count, Round.cpuCard);
        // Round.cpuCard.transform.SetParent(Cpu.cpuPile.transform);
        Debug.Log($"{Round.cpuCard} discarded");

        // Start the card return sequence if it's not already running
        if (!CardRestoration._isReturningCards)
        {
            CardRestoration.StartReturningCards(CardRestoreTime);
        }
    }

    private bool ResetTieParameter()
    {
        Debug.Log($"{_isInTie} false");
        return _isInTie = false;
    }

    public void CreateCard(GameObject card, Transform deckGameObject)
    {
        Instantiate(deckGameObject.transform);
        card.transform.SetParent(deckGameObject.transform);
    }
}