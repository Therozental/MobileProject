using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI AmountText;

    public void AddPoints(int Points)
    {
        AmountText.text = Points.ToString();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
