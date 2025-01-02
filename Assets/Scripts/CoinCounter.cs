using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;


public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI AmountText;
    [SerializeField] private Animator anim;
    private int currentPoints = 0;

    public async void UpdatePoints(int targetPoints)
    {
        await Task.Delay(300);
        PlayAnimation();
        AdjustPoints(targetPoints);
    }

    public async void AdjustPoints(int targetPoints)
    {
        int time = 100;

        // Determine the direction of adjustment (gaining or losing points)
        while (currentPoints != targetPoints)
        {
            if (currentPoints < targetPoints)
            {
                currentPoints++; // Gain points
            }
            else
            {
                currentPoints--; // Lose points
            }

            DisplayText();

            // Gradually reduce the delay time but ensure it doesn't go below 10ms
            time = Mathf.Max(10, time - time / 2);
            await Task.Delay(time);
        }
    }
    /*
    public async void UpdatePoints(int Points)
    {
        await Task.Delay(300);
        PlayAnimation();
        GainCoins(Points);
    }
    
    public async void UpdateDecreasePoints(int Points)
    {
        await Task.Delay(300);
        PlayAnimation();
        LoseCoins(Points);
    }

    private async void GainCoins(int Points)
    {
        int time = 100;

        for (int i = currentPoints; i < Points + 1; i++)
        {
            {
                currentPoints++;
                DisplayText();
                time -= time / 2;
                await Task.Delay(time);
            }
        }
    }
    
    public async void LoseCoins(int Points)
    {
        int time = 100;

        for (int i = currentPoints; i < Points - 1; i++)
        {
            {
                currentPoints--;
                DisplayText();
                time -= time / 2;
                await Task.Delay(time);
            }
        }
    }
    */

    public void PlayAnimation()
    {
        anim.SetTrigger("Gain");
    }

    public void DisplayText()
    {
        AmountText.text = currentPoints.ToString();
    }
}