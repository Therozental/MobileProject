using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;

public class ProgressBar : MonoBehaviour
{
    [Header("Progress Bar Stats")]
    public Slider progressBar;
    public TextMeshProUGUI ValueText;
    public Player Player;
    public PopupManager popupManager;
    public AudioManager audioManager;

    [SerializeField] private float speed;

    public void Update()
    {
        ValueText.text = progressBar.value.ToString() + "/" + progressBar.maxValue.ToString();
    }

    public void GetExp(int expPoints)
    {
        if (progressBar.value >= progressBar.maxValue) //(Exp >= Max points)
        {
            LevelUp();
        }

        //adding exp
        float currentValue = progressBar.value;
        currentValue += expPoints;
        progressBar.DOValue(currentValue, speed).Play();
    }

    private void LevelUp()
    {
        Player.Level++;
        audioManager.PlaySfx(audioManager.levelUp);
        popupManager.leveUpPopup.SetActive(true);
        ResetExp();
        progressBar.DOValue(0, speed).Play();
        IncreaseMaxBarValue();
    }

    private int ResetExp()
    {
        return (int)(progressBar.value = 0);
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