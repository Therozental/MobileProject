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

    public async void UpdatePoints(int Points)
    {
        await Task.Delay(300);
        PlayAnimation();
        GainCoins(Points);
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

    private void PlayAnimation()
    {
        anim.SetTrigger("Gain");
    }

    public void DisplayText()
    {
        AmountText.text = currentPoints.ToString();
    }
}