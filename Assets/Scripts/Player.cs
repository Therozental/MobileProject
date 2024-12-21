using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int Points = 0;
    public int Exp = 0;
    public int MaxExpValue = 100;
    public int Level = 0;
    public int Cash = 0;

    [Header("ProgressBar")] public Slider progressBar;
    public TextMeshProUGUI ValueText;


    [SerializeField] private Transform playerPile;


    public void Update()
    {
        ValueText.text = progressBar.value.ToString() + "/100";
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