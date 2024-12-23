using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI AmountText;

    public void AddPoints(int Points)
    {
        AmountText.text = Points.ToString();
    }
}