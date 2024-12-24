using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [Header("Progress Bar Stats")]
    public Slider progressBar;
    public TextMeshProUGUI ValueText;
    public Player Player;
    
    
    public void Update()
    {
        ValueText.text = progressBar.value.ToString() + "/" + progressBar.maxValue.ToString();
    }
    
    public void GetExp(int expPoints)
    {
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
        Player.Level++;
       // GameManager.instance.audioManager.PlaySfx(audioManager.warWin);
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
        int levelInt = Player.Level * 5; //get the int for the player level and multiply by 5
        progressBar.maxValue += levelInt;
        // MaxExpValue += levelInt; // add the number to the exp
        //progressBar.maxValue = MaxExpValue;

        Debug.Log($"max exp increased to {progressBar.maxValue}");
        return (int)progressBar.maxValue;
    }
}
