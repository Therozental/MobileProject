using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public int Points = 0;
    public int Level = 0;
    public int Cash = 0;
    public Deck Deck;

    [Header("Progress Bar Stats")]
    public Slider progressBar;
    public TextMeshProUGUI ValueText;
    
    [SerializeField] private Transform playerPile;


    public void Update()
    {
        ValueText.text = progressBar.value.ToString() + "/" + progressBar.maxValue.ToString();
    }

    private async Task DrawCard(Card _playerCard)
    {
        await Task.Delay(100);
        _playerCard = Deck.DrawTopCard(); // remove the top card from the pile
        // _playerCard.gameObject.SetActive(true);
        Debug.Log($"Player card {_playerCard}");

        
    }
    
    public void GetExp()
    {
        int expPoints = 10;
        // int expPoints = Random.Range(5, 20);
        progressBar.value += expPoints;
        //Exp += expPoints;

        if (progressBar.value >= 100) //(Exp >= 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        IncreaseMaxBarValue();
        ResetExp();
    }

    private int ResetExp()
    {
        return (int)(progressBar.value = 0);
        //  return Exp = 0;
    }

    private int IncreaseMaxBarValue()
    {
        int levelInt = Level * 5; //get the int for the player level and multiply by 5
        progressBar.maxValue += levelInt;
        // MaxExpValue += levelInt; // add the number to the exp
        //progressBar.maxValue = MaxExpValue;

        Debug.Log($"max exp increased to {progressBar.maxValue}");
        return (int)progressBar.maxValue;
    }
}