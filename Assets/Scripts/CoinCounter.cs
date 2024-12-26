using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI AmountText;

    public void UpdatePoints(int Points)
    {
        AmountText.text = Points.ToString();
    }
}