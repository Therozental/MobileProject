using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;
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
    
    public async void GetExp(int expPoints)
    {
        // int expPoints = Random.Range(5, 20);
        int time = 300;

        await Task.Delay(300);
        for (float i = 0; i < expPoints + 1; i++)
        {
            {
                progressBar.value++;
                time -= time / 2;
                await Task.Delay(time);
            }
        }
        //progressBar.value += expPoints;
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
